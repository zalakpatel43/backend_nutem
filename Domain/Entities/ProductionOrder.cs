using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_ProductionOrder")]
    public class ProductionOrder : BaseAuditable
    {
        public ProductionOrder()
        {
            //this.LiquidPreparationEntities = new List<LiquidPreparationEntity>();
            //this.PalletPackingEntities = new List<PalletPackingEntity>();
            //this.PostCheckListEntities = new List<PostCheckListEntity>();
            //this.PreCheckListEntities = new List<PreCheckListEntity>();
            this.WeightCheck = new List<WeightCheck>();
            this.AttributeCheck = new List<AttributeCheck>();
            //this.AttributeCheckEntities = new List<AttributeCheckEntity>();
        }
        public string Code { get; set; }
        public string PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public decimal? PlannedQty { get; set; } = 0;
        public string? ItemName { get; set; }
        public bool IsActive { get; set; }
        public string? ItemNo { get; set; }
        public string? InventoryUOM { get; set; }
        public long? ProductId { get; set; }
        public string? Status { get; set; }
        //public virtual ICollection<LiquidPreparationEntity> LiquidPreparationEntities { get; set; }
        //public virtual ICollection<PalletPackingEntity> PalletPackingEntities { get; set; }
        //public virtual ICollection<PostCheckListEntity> PostCheckListEntities { get; set; }
        //public virtual ICollection<PreCheckListEntity> PreCheckListEntities { get; set; }
        public virtual ICollection<WeightCheck> WeightCheck { get; set; }
        public virtual ICollection<AttributeCheck> AttributeCheck { get; set; }
        //public virtual ICollection<AttributeCheckEntity> AttributeCheckEntities { get; set; }
        //public virtual ICollection<DowntimeTrackingEntity> DowntimeTrackingEntities { get; set; }
    }
}
