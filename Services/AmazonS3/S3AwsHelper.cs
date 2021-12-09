using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Services.AmazonS3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public interface IS3AwsHelper
    {
        Task<AwsManagerResponse> AwsUploadFile(string key, IFormFile file);
    }
    
    public class S3AwsHelper : IS3AwsHelper
    {
        private readonly IAmazonS3 _amazonS3;
        public S3AwsHelper()
        {
            var chain = new CredentialProfileStoreChain("App_data\\credentials.ini");
            AWSCredentials awsCredentials;
            RegionEndpoint uSEast1 = RegionEndpoint.USEast1;
            if (chain.TryGetAWSCredentials("default", out awsCredentials))
            {
                _amazonS3 = new AmazonS3Client(awsCredentials.GetCredentials().AccessKey, awsCredentials.GetCredentials().SecretKey, uSEast1);
            }
        }

        public async Task<AwsManagerResponse> AwsUploadFile(string key, IFormFile file)
        {
            try
            {
                var putRequest = new PutObjectRequest()
                {
                    BucketName = "cohorte-noviembre-c218def1",
                    Key = key,
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType,
                    CannedACL = S3CannedACL.PublicRead
                };
                var result = await _amazonS3.PutObjectAsync(putRequest);
                var response = new AwsManagerResponse
                {
                    Message = "File upload successfully",
                    Code = (int)result.HttpStatusCode,
                    NameImage = key,
                    Url = $"https://cohorte-noviembre-c218def1.s3.amazonaws.com/{key}"
                };
                return response;
            }
            catch (AmazonS3Exception e)
            {
                return new AwsManagerResponse
                {
                    Message = "Error encountered when writing an object",
                    Code = (int)e.StatusCode,
                    Errors = e.Message
                };
            }
            catch (Exception e)
            {
                return new AwsManagerResponse
                {
                    Message = "Unknown encountered on server when writing an object",
                    Code = 500,
                    Errors = e.Message
                };
            }
        }

    }
}
