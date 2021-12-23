using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper.FromFileData
{
    public class FormFileData 
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
    }
}
