using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Skyward.Model
{
    [Table("adm_Masters")]
    public class MastersEntity : BaseAuditable
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }

        //public virtual ICollection<DowntimeTrackingEntity> DowntimeTrack { get; set; }
        public virtual ICollection<PostCheckListEntity> PostCheckListEntity { get; set; }
        public virtual ICollection<PreCheckListEntity> PreCheckListEntity { get; set; }
        public virtual ICollection<DowntimeTracking> DowntimeTracking { get; set; }
        public virtual ICollection<TrailerInspection> TrailerInspection { get; set; }
    }
}
