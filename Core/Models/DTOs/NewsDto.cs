using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTOs
{
    public class NewsDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
    }
}
