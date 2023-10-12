using _2.Models;
using Microsoft.EntityFrameworkCore;

namespace _2.Context
{
    public class MyContext:DbContext
    {

        public MyContext(DbContextOptions options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Team> Teams { get; set; }
        public DbSet<UserTeam> UserTeam { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(p => p.Orders)
                .WithOne(p => p.User!)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserTeam>()
    .HasKey(ut => new { ut.UserId, ut.TeamId });

            modelBuilder.Entity<UserTeam>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTeam)
                .HasForeignKey(ut => ut.UserId);

            modelBuilder.Entity<UserTeam>()
                .HasOne(ut => ut.Team)
                .WithMany(t => t.UserTeam)
                .HasForeignKey(ut => ut.TeamId);
        }
    }
}
