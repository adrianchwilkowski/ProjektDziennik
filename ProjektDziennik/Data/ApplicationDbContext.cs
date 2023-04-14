using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjektDziennik.Models;


namespace ProjektDziennik.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Mark>()
                    .HasOne(m => m.Student)
                    .WithMany(t => t.StudentMarks)
                    .HasForeignKey(m => m.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Mark>()
                    .HasOne(m => m.Teacher)
                    .WithMany(t => t.TeacherMarks)
                    .HasForeignKey(m => m.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasDefaultSchema("Identity");
            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        /*public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }*/
    }
}