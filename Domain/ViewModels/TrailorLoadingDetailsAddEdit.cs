using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class TrailerLoadingDetailsAddEdit
    {
        public long Id { get; set; }
        public long? HeaderId { get; set; }
        public long? ProductId { get; set; }
        public int PalletQty { get; set; }
        public string ProductionOrder { get; set; }
        public long? ActionTakenBy { get; set; }
        public string DoneByUserIds { get; set; }
        public long[] DoneByUserIdList { get; set; }
        public string DoneByUserNames { get; set; }
        public bool? IsActive { get; set; }

        //public List<TrailerLoadingSubDetailsAddEdit> TrailerLoadingSubDetails { get; set; } = new List<TrailerLoadingSubDetailsAddEdit>();
    }
}
