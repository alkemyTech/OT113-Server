using System;
using System.Threading.Tasks;
using Core.Business.Interfaces;
using Core.Helper;
using Microsoft.AspNetCore.Http;
using Services;

namespace Core.Business
{
    public class AmazonS3Business : IAmazonS3Business
    {

        private readonly IS3AwsHelper _s3AwsHelper;


        public AmazonS3Business(IS3AwsHelper s3AwsHelper)
        {
            
            _s3AwsHelper = s3AwsHelper;

        }

        public async Task<String> Save(string fileName, IFormFile image)
        {

            if (ValidateFiles.ValidateImage(image))
            {

                var response = await _s3AwsHelper.AwsUploadFile(fileName, image);

                return response.ToString();
            }

            return null;
        }

    }
}