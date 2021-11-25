using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class Slides : EntityBase
    {
        public string ImgUrl { get; set; }

        public string Text { get; set; }

        public int Order { get; set; }

        public int OrganizationId { get; set; }

    }
}
