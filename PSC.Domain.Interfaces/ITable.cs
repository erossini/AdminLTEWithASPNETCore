using System;

namespace PSC.Domain.Interfaces
{
    public interface ITable
    {
        public long ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}