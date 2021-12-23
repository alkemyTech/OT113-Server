using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface IFormFile<T> : ICrud<T>
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
       
    }
}

