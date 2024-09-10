using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skyward.Model;

namespace Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, long>
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermissionMap> RolePermissionMaps { get; set; }
        public DbSet<WeightCheck> WeightCheck { get; set; }
        public DbSet<PalletPacking> PalletPacking { get; set; }

        public DbSet<PalletPackingDetails> PalletPackingDetails { get; set; }
        public DbSet<DowntimeTracking> DowntimeTracking { get; set; }
        public DbSet<DowntimeTrackingDetails> DowntimeTrackingDetails { get; set; } // Ensure this is added
        public DbSet<AttributeCheck> AttributeCheck { get; set; }
        public DbSet<ProductionOrder> ProductionOrder { get; set; }
        public DbSet<ProductMaster> ProductMaster { get; set; }
        public DbSet<TrailerLoading> TrailerLoading { get; set; }
        public DbSet<TrailerLoadingDetails> TrailerLoadingDetails { get; set; }
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

            modelBuilder.Entity<Company>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Company>()
                .ToTable("adm_Company");

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

            //modelBuilder.Entity<PrePostQuestionEntity>()
            //    .HasMany(pp => pp.PostCheckListDetails) 
            //    .WithOne()
            //    .HasForeignKey(pc => pc.PrePostQuestionId);

            modelBuilder.Entity<PreCheckListEntity>()
                .HasKey(pcl => pcl.Id);

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


            // TrailerLoading Entity Configuration
            modelBuilder.Entity<TrailerLoading>()
                .HasKey(tl => tl.Id);

            modelBuilder.Entity<TrailerLoading>()
                .HasOne(tl => tl.HeadUser)
                .WithMany()
                .HasForeignKey(tl => tl.SupervisedBy)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TrailerLoading>()
                .ToTable("adm_TrailerLoadingHeader");

            modelBuilder.Entity<TrailerLoadingDetails>()
                .HasKey(tld => tld.Id);

            modelBuilder.Entity<TrailerLoadingDetails>()
                .HasOne(tld => tld.TrailerLoading)
                .WithMany(tl => tl.TrailerLoadingDetails)
                .HasForeignKey(tld => tld.HeaderId);

            modelBuilder.Entity<TrailerLoadingDetails>()
                .HasOne(dt => dt.ProductionOrderid)
                .WithMany(po => po.TrailerLoadingDetails) // Ensure navigation property name is correct
                .HasForeignKey(dt => dt.ProductionOrder);

            modelBuilder.Entity<TrailerLoadingDetails>()
                .ToTable("adm_TrailerLoadingDetails");

            modelBuilder.Entity<PalletPacking>()
           .HasKey(pp => pp.Id);

            modelBuilder.Entity<PalletPacking>()
                .HasOne(pp => pp.ProductMaster)
                .WithMany(pm => pm.PalletPacking)
                .HasForeignKey(pp => pp.ProductId);

            modelBuilder.Entity<PalletPacking>()
                .HasOne(pp => pp.ProductionOrder)
                .WithMany(po => po.PalletPacking)
                .HasForeignKey(pp => pp.SAPProductionOrderId);

            modelBuilder.Entity<PalletPacking>()
                    .HasOne(tl => tl.HeadUser)
                    .WithMany()
                    .HasForeignKey(tl => tl.SupervisedBy)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PalletPacking>()
                .ToTable("adm_PalletPackingHeader");

            modelBuilder.Entity<PalletPackingDetails>()
                .HasKey(ppd => ppd.Id);

            modelBuilder.Entity<PalletPackingDetails>()
                .HasOne(ppd => ppd.PalletPacking)
                .WithMany(pp => pp.PalletPackingDetails)
                .HasForeignKey(ppd => ppd.HeaderId);

            modelBuilder.Entity<PalletPackingDetails>()
                .ToTable("adm_PalletPackingDetails");


            // Configure RolePermissionMap
            modelBuilder.Entity<RolePermissionMap>()
                .HasKey(rp => rp.Id);

            modelBuilder.Entity<RolePermissionMap>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);



            modelBuilder.Entity<RolePermissionMap>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);
        

            modelBuilder.Entity<RolePermissionMap>()
                .ToTable("adm_RolePermissionMap");





        }
    }
}
