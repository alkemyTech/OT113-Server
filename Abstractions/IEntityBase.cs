using System;

namespace Abstractions
{
    public interface IEntityBase
    {
        public int Id { get; set; }

        public bool isDelete { get; set; }

        public DateTime modifiedAt { get; set; }
    }
}
