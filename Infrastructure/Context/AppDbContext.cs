using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, long>
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermissionMap> RolePermissionMaps { get; set; }
        public DbSet<WeightCheck> WeightCheck { get; set; }
        public DbSet<AttributeCheck> AttributeCheck { get; set; }
        public DbSet<ProductionOrder> ProductionOrder { get; set; }
        public DbSet<ProductMaster> ProductMaster { get; set; }
        public DbSet<ShiftMaster> ShiftMaster { get; set; }
        public DbSet<WeightCheckDetails> WeightCheckDetails { get; set; }
        public DbSet<WeightCheckSubDetails> WeightCheckSubDetails { get; set; }
        public DbSet<AttributeCheckDetails> AttributeCheckDetails { get; set; }
        public DbSet<NozzelMaster> NozzelMaster { get; set; }

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
                .ToTable("adm_AttributeCheckHeader");
            // AttributeCheckDetails entity configuration
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
        }
    }
}
