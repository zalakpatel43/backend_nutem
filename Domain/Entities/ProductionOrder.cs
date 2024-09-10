using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_ProductionOrder")]
    public class ProductionOrder : BaseAuditable
    {
        public ProductionOrder()
        {
            this.LiquidPreparation = new List<LiquidPreparation>();
            //this.PalletPackingEntities = new List<PalletPackingEntity>();
            this.PostCheckListEntity = new List<PostCheckListEntity>();
            this.PreCheckListEntity = new List<PreCheckListEntity>();
            this.WeightCheck = new List<WeightCheck>();
            this.AttributeCheck = new List<AttributeCheck>();
            this.TrailerLoadingDetails = new List<TrailerLoadingDetails>();
            this.DowntimeTracking=new List<DowntimeTracking>();
            this.PalletPacking = new List<PalletPacking>();
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
        [JsonIgnore]
        public virtual ICollection<PostCheckListEntity> PostCheckListEntity { get; set; }
        [JsonIgnore]
        public virtual ICollection<PreCheckListEntity> PreCheckListEntity { get; set; }
        [JsonIgnore]
        public virtual ICollection<WeightCheck> WeightCheck { get; set; }
        [JsonIgnore]
        public virtual ICollection<AttributeCheck> AttributeCheck { get; set; }
        [JsonIgnore]
        public virtual ICollection<DowntimeTracking> DowntimeTracking { get; set; }
        public virtual ICollection<LiquidPreparation> LiquidPreparation { get; set; }
        public virtual ICollection<PalletPacking> PalletPacking { get; set; }
        public virtual ICollection<TrailerLoadingDetails> TrailerLoadingDetails { get; set; }
        //public virtual ICollection<AttributeCheckEntity> AttributeCheckEntities { get; set; }
        //public virtual ICollection<DowntimeTrackingEntity> DowntimeTrackingEntities { get; set; }
    }
}
