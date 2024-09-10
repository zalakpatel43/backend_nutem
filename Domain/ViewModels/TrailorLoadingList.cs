using System;

namespace Domain.ViewModels
{
    public class TrailerLoadingList
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? TLDateTime { get; set; }
        public string DoorNo { get; set; }
        public string TrailerNo { get; set; }
        public string BOLNo { get; set; }
        public long? SupervisedBy { get; set; }
        public string SupervisedName { get; set; }
        public DateTime? SupervisedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
