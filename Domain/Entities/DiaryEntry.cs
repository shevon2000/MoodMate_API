namespace Domain.Entities
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime EntryDate { get; set; }
        public string Mood { get; set; } = string.Empty;
        public string Thoughts { get; set; } = string.Empty;
        public User? User { get; set; }
    }
}
