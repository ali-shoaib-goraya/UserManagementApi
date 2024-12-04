using Microsoft.EntityFrameworkCore;
using UserManagementApi.Interfaces;
using UserManagementApi.Models;

namespace UserManagementApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<UserCampus> UserCampuses { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Primary Key for UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserID, ur.RoleID });

            // Composite Primary Key for RolePermission
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleID, rp.PermissionID });

            // Composite Primary Key for UserCampus
            modelBuilder.Entity<UserCampus>()
                .HasKey(uc => new { uc.UserID, uc.CampusID });

            // User-Campus Relationship
            modelBuilder.Entity<UserCampus>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCampuses)
                .HasForeignKey(uc => uc.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserCampus>()
                .HasOne(uc => uc.Campus)
                .WithMany()
                .HasForeignKey(uc => uc.CampusID)
                .OnDelete(DeleteBehavior.Cascade);

            // User-Role Relationship
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleID)
                .OnDelete(DeleteBehavior.Cascade);

            // Role-Permission Relationship
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionID)
                .OnDelete(DeleteBehavior.Cascade);

            // School-Campus Relationship
            modelBuilder.Entity<School>()
                .HasOne(s => s.Campus)
                .WithMany(c => c.Schools)
                .HasForeignKey(s => s.CampusID)
                .OnDelete(DeleteBehavior.Cascade);

            // Department-School Relationship
            modelBuilder.Entity<Department>()
                .HasOne(d => d.School)
                .WithMany(s => s.Departments)
                .HasForeignKey(d => d.SchoolID)
                .OnDelete(DeleteBehavior.Cascade);

            //// User-School Relationship
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.School)
            //    .WithMany()
            //    .HasForeignKey(u => u.SchoolID)
            //    .OnDelete(DeleteBehavior.Cascade);

            // User-Department Relationship
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Department)
            //    .WithMany()
            //    .HasForeignKey(u => u.DepartmentID)
            //    .OnDelete(DeleteBehavior.Cascade);
            // Global Query Filters for Soft Delete
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<UserCampus>().HasQueryFilter(uc => !uc.IsDeleted);
            modelBuilder.Entity<Campus>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<School>().HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<Department>().HasQueryFilter(d => !d.IsDeleted);
            modelBuilder.Entity<UserRole>().HasQueryFilter(ur => !ur.IsDeleted);
            modelBuilder.Entity<RolePermission>().HasQueryFilter(rp => !rp.IsDeleted);
            modelBuilder.Entity<Permission>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            HandleSoftDelete();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleSoftDelete();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void HandleSoftDelete()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted))
            {
                if (entry.Entity is ISoftDeletable softDeletableEntity)
                {
                    entry.State = EntityState.Modified;
                    softDeletableEntity.IsDeleted = true;
                    softDeletableEntity.DeletedAt = DateTime.UtcNow;
                }
            }
        }
    }
}


