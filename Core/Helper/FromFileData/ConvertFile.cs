using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper.FromFileData
{
    public class ConvertFile 
    {
        public static IFormFile BinaryToFormFile(byte[] bytes, FormFileData formFileData)
        {
            MemoryStream stream = new MemoryStream(bytes);
            IFormFile file = new FormFile(stream, 0, bytes.Length, formFileData.Name, formFileData.FileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = formFileData.ContentType
            };
            return file;
        }
    }
}
