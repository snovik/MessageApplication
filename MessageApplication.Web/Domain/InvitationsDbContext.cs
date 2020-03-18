using Microsoft.EntityFrameworkCore;

namespace MessageApplication.Web.Domain
{
    public class InvitationsDbContext : DbContext
    {
        public DbSet<Invitation> Invitations { get; set; }

        public InvitationsDbContext(DbContextOptions<InvitationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invitation>()
                .HasKey(key => key.Id);

            modelBuilder.Entity<Invitation>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Invitation>()
                .HasIndex(i => i.Phone)
                .IsUnique();

            modelBuilder.Entity<Invitation>()
                .Property(p => p.Phone)
                .IsRequired();

            modelBuilder.Entity<Invitation>()
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("sysdatetime()")
                .IsRequired();
        }
    }
}
