using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTOs
{
    public class SlidesCreateDTO
    {
        public string ImageUrl { get; set; }
        public string Order { get; set; }
        public string FileName { get; internal set; }
        public string ContentType { get; internal set; }
        public string Name { get; internal set; }
    }
}
