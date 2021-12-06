using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Core.Helper
{

    public class ValidateFiles
    {
        public static bool ValidateImage(IFormFile image)
        {
            var postedFileExtension = Path.GetExtension(image.FileName);
            if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return true;
        }

    }
    
}