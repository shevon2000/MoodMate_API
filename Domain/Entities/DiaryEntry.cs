using System;

namespace Domain.Entities
{
    public class DiaryEntry
    {
        public DiaryEntry()
        {
            Content = string.Empty;
            FilePath = string.Empty;
            AppUser = null!;
        }

        public Guid Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string Content { get; set; }
        public int MoodRating { get; set; } // Scale of 1-10
        public string FilePath { get; set; } // Path to the stored file
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}