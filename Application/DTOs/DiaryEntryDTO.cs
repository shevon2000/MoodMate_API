namespace Application.DTOs
{
    public class DiaryEntryDTO
    {
        public int Id { get; set; } // Needed for Update/Delete operations

        public string Date { get; set; } = string.Empty; // e.g., "2025-04-29"
        
        public string Time { get; set; } = string.Empty; // e.g., "22:30:00"

        public string Mood { get; set; } = string.Empty; // e.g., "Happy", "Angry"

        public int MoodScore { get; set; } // Mood score out of 10 (e.g., 7/10)

        public string Thoughts { get; set; } = string.Empty; // The diary content

        public string? Sentiment { get; set; } // Optional: "Positive", "Neutral", "Negative"

        public string UserId { get; set; } = string.Empty; // Link the entry to a specific user
    }
}
