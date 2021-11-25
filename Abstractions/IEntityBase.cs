using System;

namespace Abstractions
{
    public interface IEntityBase
    {
        public int Id { get; set; }

        public bool isDelete { get; set; }

<<<<<<< HEAD
        public DateTime modifiedAt { get; set; }
=======
        public DateTime modifiedAt { get; set;}
>>>>>>> 3140818aee11d4b4e85d128c575d01432a9d13aa
    }
}
