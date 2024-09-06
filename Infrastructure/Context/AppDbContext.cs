using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skyward.Model;

namespace Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, long>
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermissionMap> RolePermissionMaps { get; set; }
        public DbSet<WeightCheck> WeightCheck { get; set; }
        public DbSet<DowntimeTracking> DowntimeTracking { get; set; }
        public DbSet<DowntimeTrackingDetails> DowntimeTrackingDetails { get; set; } // Ensure this is added
        public DbSet<AttributeCheck> AttributeCheck { get; set; }
        public DbSet<ProductionOrder> ProductionOrder { get; set; }
        public DbSet<ProductMaster> ProductMaster { get; set; }
        public DbSet<ShiftMaster> ShiftMaster { get; set; }
        public DbSet<CauseMaster> CauseMaster { get; set; }
        public DbSet<MastersEntity> Master { get; set; }
        public DbSet<WeightCheckDetails> WeightCheckDetails { get; set; }
        public DbSet<WeightCheckSubDetails> WeightCheckSubDetails { get; set; }
        public DbSet<AttributeCheckDetails> AttributeCheckDetails { get; set; }
        public DbSet<NozzelMaster> NozzelMaster { get; set; }
        public DbSet<PrePostQuestionEntity> PrePostQuestion { get; set; }
        public DbSet<PreCheckListEntity> PreCheckListEntity { get; set; } 
        public DbSet<PreCheckListDetailEntity> PreCheckListDetailEntity { get; set; }
        public DbSet<CompanyMaster> CompanyMaster { get; set; }
        public DbSet<TrailerInspection> TrailerInspection { get; set; }

        public DbSet<PostCheckListEntity> PostCheckListEntity { get; set; }
        public DbSet<PostCheckListDetailEntity> PostCheckListDetailEntity { get; set; }
        public DbSet<TankMaster> TankMaster { get; set; }

        public DbSet<StartEndBatchChecklist> StartEndBatchChecklist { get; set; }
        public DbSet<MaterialMaster> MaterialMaster { get; set; }
        public DbSet<ProductInstructionDetails> ProductInstructionDetails { get; set; }
        public DbSet<QCTSpecificationMaster> QCTSpecificationMaster { get; set; }
        public DbSet<LiquidPreparation> LiquidPreparation { get; set; }
        public DbSet<LiquidPreparationInstructionDetails> LiquidPreparationInstructionDetails { get; set; }
        public DbSet<LiquidPreparationChecklistDetails> LiquidPreparationChecklistDetails { get; set; }
        public DbSet<LiquidPreparationSpecificationDetails> LiquidPreparationSpecificationDetails { get; set; }
        public DbSet<LiquidPreparationAdjustmentDetails> LiquidPreparationAdjustmentDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RolePermissionMap>()
                .HasOne(mg => mg.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(mg => mg.RoleId)
                .IsRequired();

            modelBuilder.Entity<RolePermissionMap>()
                .HasOne(mg => mg.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(mg => mg.PermissionId)
                .IsRequired();

            modelBuilder.Entity<WeightCheck>()
                .HasKey(wc => wc.Id);

            modelBuilder.Entity<WeightCheck>()
                .HasOne(wc => wc.ProductionOrder)
                .WithMany(po => po.WeightCheck)
                .HasForeignKey(wc => wc.SAPProductionOrderId);

            modelBuilder.Entity<WeightCheck>()
                .HasOne(wc => wc.ShiftMaster)
                .WithMany(po => po.WeightCheck)
                .HasForeignKey(wc => wc.ShiftId);

            modelBuilder.Entity<WeightCheck>()
                .HasOne(wc => wc.ProductMaster)
                .WithMany(po => po.WeightCheck)
                .HasForeignKey(wc => wc.ProductId);

            modelBuilder.Entity<WeightCheck>()
                .ToTable("adm_WeightCheckHeader");

            modelBuilder.Entity<AttributeCheck>()
                .HasKey(ac => ac.Id);

            modelBuilder.Entity<AttributeCheck>()
                .HasOne(ac => ac.ProductionOrder)
                .WithMany(po => po.AttributeCheck)
                .HasForeignKey(ac => ac.ProductionOrderId);

            modelBuilder.Entity<AttributeCheck>()
                .HasOne(ac => ac.ProductMaster)
                .WithMany(pm => pm.AttributeCheck)
                .HasForeignKey(ac => ac.ProductId);

            modelBuilder.Entity<AttributeCheck>()
                .Property(ac => ac.ACDate) // Configure the new property
                .HasColumnName("ACDate")
                .IsRequired(false); // Or configure it as required based on your needs

            modelBuilder.Entity<AttributeCheck>()
                .ToTable("adm_AttributeCheckHeader");

            modelBuilder.Entity<AttributeCheckDetails>()
                .HasKey(acd => acd.Id);

            modelBuilder.Entity<AttributeCheckDetails>()
                .HasOne(acd => acd.AttributeCheck)
                .WithMany(ac => ac.AttributeCheckDetails)
                .HasForeignKey(acd => acd.HeaderId);

            modelBuilder.Entity<AttributeCheckDetails>()
                .ToTable("adm_AttributeCheckDetails");


            modelBuilder.Entity<ProductionOrder>()
                .HasKey(po => po.Id);

            modelBuilder.Entity<ProductionOrder>()
                .ToTable("adm_ProductionOrder");

            modelBuilder.Entity<ProductMaster>()
                .HasKey(pm => pm.Id);

            modelBuilder.Entity<ProductMaster>()
                .ToTable("adm_ProductMaster");

            modelBuilder.Entity<ShiftMaster>()
                .HasKey(sm => sm.Id);

            modelBuilder.Entity<ShiftMaster>()
                .ToTable("adm_ShiftMaster");

            modelBuilder.Entity<NozzelMaster>()
                .HasKey(nm => nm.Id);

            modelBuilder.Entity<NozzelMaster>()
                .ToTable("adm_NozzelMaster");

            modelBuilder.Entity<WeightCheckDetails>()
                .HasKey(wcd => wcd.Id);

            modelBuilder.Entity<WeightCheckDetails>()
                .HasOne(wcd => wcd.WeightCheck)
                .WithMany(wc => wc.WeightCheckDetails)
                .HasForeignKey(wcd => wcd.HeaderId);

            modelBuilder.Entity<WeightCheckDetails>()
                .ToTable("adm_WeightCheckDetails");

            modelBuilder.Entity<WeightCheckSubDetails>()
                .HasKey(wcsd => wcsd.Id);

            modelBuilder.Entity<WeightCheckSubDetails>()
                .HasOne(wcsd => wcsd.NozzelMaster)
                .WithMany(nm => nm.WeightCheckSubDetails)
                .HasForeignKey(wcsd => wcsd.NozzleId);

            modelBuilder.Entity<WeightCheckSubDetails>()
                .HasOne(wcsd => wcsd.WeightCheckDetails)
                .WithMany(wcd => wcd.WeightCheckSubDetails)
                .HasForeignKey(wcsd => wcsd.DetailId);

            modelBuilder.Entity<WeightCheckSubDetails>()
                .ToTable("adm_WeightCheckSubDetails");

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);
            // Configure entity relationships and constraints here

            // Configure CauseMasterEntity
            modelBuilder.Entity<CauseMaster>()
                .HasKey(cm => cm.Id); // Ensure that Id property exists

            modelBuilder.Entity<CauseMaster>()
                .ToTable("adm_CauseMaster");

            // Configure MastersEntity
            modelBuilder.Entity<MastersEntity>()
                .HasKey(m => m.Id); // Ensure that Id property exists

            modelBuilder.Entity<MastersEntity>()
                .ToTable("adm_Masters");
            modelBuilder.Entity<DowntimeTracking>()
            .HasKey(dt => dt.Id); // Set primary key

            modelBuilder.Entity<DowntimeTracking>()
                .HasOne(dt => dt.ProductionOrder)
                .WithMany(po => po.DowntimeTracking) // Ensure navigation property name is correct
                .HasForeignKey(dt => dt.SAPProductionOrderId);

            modelBuilder.Entity<DowntimeTracking>()
                .HasOne(dt => dt.ProductMaster)
                .WithMany(pm => pm.DowntimeTracking) // Ensure navigation property name is correct
                .HasForeignKey(dt => dt.ProductId);

            modelBuilder.Entity<DowntimeTracking>()
                .HasOne(dt => dt.Masters)
                .WithMany(m => m.DowntimeTracking) // Ensure navigation property name is correct
                .HasForeignKey(dt => dt.ProductLineId);

            modelBuilder.Entity<DowntimeTracking>()
                .ToTable("adm_DowntimeTracking");

            modelBuilder.Entity<DowntimeTrackingDetails>()
                .HasKey(dtd => dtd.Id);

            modelBuilder.Entity<DowntimeTrackingDetails>()
                .HasOne(dtd => dtd.DowntimeTracking)
                .WithMany(dt => dt.DownTimeTrackingDetails)
                .HasForeignKey(dtd => dtd.HeaderId);

            modelBuilder.Entity<DowntimeTrackingDetails>()
                .ToTable("adm_DowntimeTrackingDetails");

            modelBuilder.Entity<PrePostQuestionEntity>()
                .HasKey(pp => pp.Id);

            modelBuilder.Entity<PrePostQuestionEntity>()
                .ToTable("adm_PrePostQuestion");

            modelBuilder.Entity<PrePostQuestionEntity>()
                .HasMany(pp => pp.PreCheckList)
                .WithOne(pcl => pcl.PrePostQuestion)
                .HasForeignKey(pcl => pcl.PrePostQuestionId);

            modelBuilder.Entity<PrePostQuestionEntity>()
                .HasMany(pp => pp.PostCheckListDetails)
                .WithOne(pcld => pcld.PrePostQuestion)
                .HasForeignKey(pcld => pcld.PrePostQuestionId);


            modelBuilder.Entity<PreCheckListEntity>()
                .HasKey(pcl => pcl.Id);

            modelBuilder.Entity<PreCheckListEntity>()
                .HasOne(pcl => pcl.ProductMaster)
                .WithMany(pm => pm.PreCheckListEntity) // Ensure that `PreCheckLists` is a navigation property in `ProductMaster`
                .HasForeignKey(pcl => pcl.ProductId);

            modelBuilder.Entity<PreCheckListEntity>()
                .HasOne(pcl => pcl.ShiftMaster)
                .WithMany(sm => sm.PreCheckListEntity) // Ensure that `PreCheckLists` is a navigation property in `ShiftMaster`
                .HasForeignKey(pcl => pcl.ShiftId);

            modelBuilder.Entity<PreCheckListEntity>()
                .HasOne(pcl => pcl.Masters)
                .WithMany(sm => sm.PreCheckListEntity) // Ensure that `PreCheckLists` is a navigation property in `ShiftMaster`
                .HasForeignKey(pcl => pcl.FillingLine);

            modelBuilder.Entity<PreCheckListEntity>()
                .ToTable("adm_PreCheckList");

            modelBuilder.Entity<PreCheckListDetailEntity>()
                .HasKey(pcld => pcld.Id);

            modelBuilder.Entity<PreCheckListDetailEntity>()
                .HasOne(pcld => pcld.PreCheckList)
                .WithMany(pcl => pcl.PreCheckListDetails)
                .HasForeignKey(pcld => pcld.PreCheckListId);

            modelBuilder.Entity<PreCheckListDetailEntity>()
                .ToTable("adm_PreCheckListDetails");


            modelBuilder.Entity<CompanyMaster>()
               .HasKey(pm => pm.Id);

            modelBuilder.Entity<CompanyMaster>()
                .ToTable("adm_CompanyMaster");


            modelBuilder.Entity<TrailerInspection>()
                .HasKey(ti => ti.Id);

            modelBuilder.Entity<TrailerInspection>()
                .HasOne(wc => wc.CompanyMaster)
                .WithMany(po => po.TrailerInspection)
                .HasForeignKey(wc => wc.CompanyId);

            modelBuilder.Entity<TrailerInspection>()
                .HasOne(wc => wc.MasterEntity)
                .WithMany(po => po.TrailerInspection)
                .HasForeignKey(wc => wc.VehicleTypeId);

            modelBuilder.Entity<TrailerInspection>()
                .ToTable("adm_TrailerInspection");

            modelBuilder.Entity<TankMaster>()
              .HasKey(nm => nm.Id);

            modelBuilder.Entity<TankMaster>()
                .ToTable("adm_TankMaster");

            modelBuilder.Entity<StartEndBatchChecklist>()
             .HasKey(nm => nm.Id);

            modelBuilder.Entity<StartEndBatchChecklist>()
                .ToTable("adm_StartEndBatchChecklist");

            modelBuilder.Entity<MaterialMaster>()
             .HasKey(nm => nm.Id);

            modelBuilder.Entity<MaterialMaster>()
                .ToTable("adm_MaterialMaster");

            modelBuilder.Entity<ProductInstructionDetails>()
             .HasKey(nm => nm.Id);

            modelBuilder.Entity<ProductInstructionDetails>()
                .ToTable("adm_ProductInstructionDetails");

            modelBuilder.Entity<QCTSpecificationMaster>()
             .HasKey(nm => nm.Id);

            modelBuilder.Entity<QCTSpecificationMaster>()
                .ToTable("adm_QCTSpecificationMaster");

            modelBuilder.Entity<LiquidPreparation>()
               .HasKey(wc => wc.Id);

            modelBuilder.Entity<LiquidPreparation>()
                .HasOne(wc => wc.ShiftMaster)
                .WithMany(po => po.LiquidPreparation)
                .HasForeignKey(wc => wc.ShiftId);

            modelBuilder.Entity<LiquidPreparation>()
                .HasOne(wc => wc.ProductMaster)
                .WithMany(po => po.LiquidPreparation)
                .HasForeignKey(wc => wc.ProductId);

            modelBuilder.Entity<LiquidPreparation>()
                .HasOne(wc => wc.TankMaster)
                .WithMany(po => po.LiquidPreparation)
                .HasForeignKey(wc => wc.TankId);

            modelBuilder.Entity<LiquidPreparation>()
               .HasOne(wc => wc.ProductionOrder)
               .WithMany(po => po.LiquidPreparation)
               .HasForeignKey(wc => wc.SAPProductionOrderId);

            modelBuilder.Entity<LiquidPreparation>()
                .ToTable("adm_LiquidPreparation");

            modelBuilder.Entity<LiquidPreparationInstructionDetails>()
              .HasOne(wc => wc.LiquidPreparation)
              .WithMany(po => po.LiquidPreparationInstructionDetails)
              .HasForeignKey(wc => wc.LiquidPreparationId);

            modelBuilder.Entity<LiquidPreparationInstructionDetails>()
                 .HasOne(wc => wc.ProductInstructionDetails)
                 .WithMany(po => po.LiquidPreparationInstructionDetails)
                 .HasForeignKey(wc => wc.InstructionId);

            modelBuilder.Entity<LiquidPreparationInstructionDetails>()
                 .HasOne(wc => wc.MaterialMaster)
                 .WithMany(po => po.LiquidPreparationInstructionDetails)
                 .HasForeignKey(wc => wc.MaterialId);

            modelBuilder.Entity<LiquidPreparationInstructionDetails>()
                .ToTable("adm_LiquidPreparationInstructionDetails");

            modelBuilder.Entity<LiquidPreparationChecklistDetails>()
               .HasOne(wc => wc.TankMaster)
               .WithMany(po => po.LiquidPreparationChecklistDetails)
               .HasForeignKey(wc => wc.TankId);

            modelBuilder.Entity<LiquidPreparationChecklistDetails>()
               .HasOne(wc => wc.LiquidPreparation)
               .WithMany(po => po.LiquidPreparationChecklistDetails)
                .HasForeignKey(wc => wc.LiquidPreparationId);

            modelBuilder.Entity<LiquidPreparationChecklistDetails>()
                .ToTable("adm_LiquidPreparationChecklistDetails");

            modelBuilder.Entity<LiquidPreparationSpecificationDetails>()
                .HasOne(wc => wc.LiquidPreparation)
                .WithMany(po => po.LiquidPreparationSpecificationDetails)
                 .HasForeignKey(wc => wc.LiquidPreparationId);

            modelBuilder.Entity<LiquidPreparationSpecificationDetails>()
               .HasOne(wc => wc.QCTSpecificationMaster)
               .WithMany(po => po.LiquidPreparationSpecificationDetails)
                .HasForeignKey(wc => wc.SpecificationLimitId);

            modelBuilder.Entity<LiquidPreparationSpecificationDetails>()
                .ToTable("adm_LiquidPreparationSpecificationDetails");

            modelBuilder.Entity<LiquidPreparationAdjustmentDetails>()
               .HasOne(wc => wc.LiquidPreparation)
               .WithMany(po => po.LiquidPreparationAdjustmentDetails)
                .HasForeignKey(wc => wc.LiquidPreparationId);

            modelBuilder.Entity<LiquidPreparationAdjustmentDetails>()
             .HasOne(wc => wc.MaterialMaster)
             .WithMany(po => po.LiquidPreparationAdjustmentDetails)
              .HasForeignKey(wc => wc.MaterialId);

            modelBuilder.Entity<LiquidPreparationAdjustmentDetails>()
                .ToTable("adm_LiquidPreparationAdjustmentDetails");
            // Configure PostCheckListEntity
            modelBuilder.Entity<PostCheckListEntity>()
                .HasKey(pcl => pcl.Id);
            modelBuilder.Entity<PostCheckListEntity>()
                .HasOne(pcl => pcl.ProductMaster)
                .WithMany(pm => pm.PostCheckListEntity) // Ensure that `PreCheckLists` is a navigation property in `ProductMaster`
                .HasForeignKey(pcl => pcl.ProductId);

            modelBuilder.Entity<PostCheckListEntity>()
                .HasOne(pcl => pcl.ShiftMaster)
                .WithMany(sm => sm.PostCheckListEntity) // Ensure that `PreCheckLists` is a navigation property in `ShiftMaster`
                .HasForeignKey(pcl => pcl.ShiftId);

            modelBuilder.Entity<PostCheckListEntity>()
                .HasOne(pcl => pcl.Masters)
                .WithMany(sm => sm.PostCheckListEntity) // Ensure that `PreCheckLists` is a navigation property in `ShiftMaster`
                .HasForeignKey(pcl => pcl.FillingLine);

            modelBuilder.Entity<PostCheckListEntity>()
                .ToTable("adm_PostCheckList");

            modelBuilder.Entity<PostCheckListDetailEntity>()
                .HasKey(pcld => pcld.Id);

            modelBuilder.Entity<PostCheckListDetailEntity>()
                .HasOne(pcld => pcld.PostCheckList)
                .WithMany(pcl => pcl.PostCheckListDetails)
                .HasForeignKey(pcld => pcld.PostCheckListId);

            modelBuilder.Entity<PostCheckListDetailEntity>()
                .ToTable("adm_PostCheckListDetails");

        }
    }
}
