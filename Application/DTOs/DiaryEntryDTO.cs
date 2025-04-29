using System;

namespace Application.DTOs
{
    public class DiaryEntryDto
    {
        public Guid Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string Content { get; set; } = string.Empty;
        public int MoodRating { get; set; }
        public string FilePath { get; set; } = string.Empty;
    }
}