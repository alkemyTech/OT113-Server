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

        private readonly S3AwsHelper _s3AwsHelper;

        public AmazonS3Business(S3AwsHelper s3AwsHelper)
        {
            _s3AwsHelper = s3AwsHelper;
        }

        public async Task<String> Save(string fileName, IFormFile image)
        {

            throw new NotImplementedException();

        }

    }
}