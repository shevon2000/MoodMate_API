// Persistence/DataContext.cs
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; } = null!;
        public DbSet<DiaryEntry> DiaryEntries { get; set; } = null!;
        public DbSet<UserTask> Tasks { get; set; } = null!;
        public DbSet<HelpResource> HelpResources { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(u => u.DiaryEntries)
                .WithOne(d => d.AppUser)
                .HasForeignKey(d => d.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUser>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.AppUser)
                .HasForeignKey(t => t.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed help resources
            builder.Entity<HelpResource>().HasData(
                new HelpResource
                {
                    Id = Guid.NewGuid(),
                    Title = "Coping with Anger",
                    Content = "Recognize your triggers, practice deep breathing, count to 10 before reacting...",
                    Category = "Anger Management"
                },
                new HelpResource
                {
                    Id = Guid.NewGuid(),
                    Title = "Mindfulness Exercises",
                    Content = "Practice being present in the moment, focus on your breathing...",
                    Category = "Stress Relief"
                },
                new HelpResource
                {
                    Id = Guid.NewGuid(),
                    Title = "When to Seek Professional Help",
                    Content = "If your mood swings affect daily life or relationships...",
                    Category = "Mental Health Resources"
                }
            );
        }
    }
}