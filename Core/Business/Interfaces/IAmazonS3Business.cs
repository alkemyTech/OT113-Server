using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Business.Interfaces
{
    public interface IAmazonS3Business
    {
        Task<String> Save(string fileName, IFormFile image);
    }
}