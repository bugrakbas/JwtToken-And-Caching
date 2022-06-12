using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Odev4.Models;

namespace Odev4.Contexts
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Contents> Contents { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<FriendshipConfirmations> FriendshipConfirmations { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<HistoryMessages> HistoryMessages { get; set; }
        public DbSet<HistoryPosts> HistoryPosts { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friends>(entity =>
            {
                entity.HasOne(d => d.User)
                .WithMany(p => p.Friends)
                .HasForeignKey(d => d.FriendshipId);
            });
            modelBuilder.Entity<Contents>(entity =>
            {
                entity.HasOne(d => d.User)
                .WithMany(p => p.Contents)
                .HasForeignKey(d => d.CommentId);
            });
            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.PostId);
            });
            modelBuilder.Entity<HistoryPosts>(entity =>
            {
                entity.HasOne(d => d.User)
                .WithMany(p => p.HistoryPosts)
                .HasForeignKey(p => p.HistoryPostId);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
