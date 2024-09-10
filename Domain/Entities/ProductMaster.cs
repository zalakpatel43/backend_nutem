using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_ProductMaster")]
    public class ProductMaster : BaseAuditable
    {
        public long Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string productDescription { get; set; }
        public bool? IsActive { get; set; }
        public string? ItemNo { get; set; }
        public string? UOM { get; set; }

        //public virtual ICollection<DowntimeTrackingEntity> DowntimeTrack { get; set; }
        //public virtual ICollection<AttributeCheckEntity> AttributeCheck { get; set; }
        public virtual ICollection<PreCheckListEntity> PreCheckListEntity { get; set; }
        public virtual ICollection<PostCheckListEntity> PostCheckListEntity { get; set; }
        //public virtual ICollection<ProductInstructionDetailsEntity> ProductInstructionDetailsEntities { get; set; }
        //public virtual ICollection<LiquidPreparationEntity> LiquidPreparationEntities { get; set; }
        //public virtual ICollection<PalletPackingEntity> PalletPackingEntities { get; set; }
        public virtual ICollection<WeightCheck> WeightCheck { get; set; }
        public virtual ICollection<LiquidPreparation> LiquidPreparation { get; set; }
        public virtual ICollection<AttributeCheck> AttributeCheck { get; set; }
        public virtual ICollection<DowntimeTracking> DowntimeTracking { get; set; }
        public virtual ICollection<PalletPacking> PalletPacking { get; set; }
    }
}
