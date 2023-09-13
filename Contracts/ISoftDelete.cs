using System;

namespace PersonApi.Contracts
{
    public interface ISoftDelete
    {
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
