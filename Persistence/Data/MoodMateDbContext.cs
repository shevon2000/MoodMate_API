using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Data
{
    public class MoodMateDbContext : DbContext
    {
        public MoodMateDbContext(DbContextOptions<MoodMateDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<DiaryEntry> DiaryEntries => Set<DiaryEntry>();
        public DbSet<TaskEvent> TaskEvents => Set<TaskEvent>();
        public DbSet<Event> Events { get; set; }

    }
}
