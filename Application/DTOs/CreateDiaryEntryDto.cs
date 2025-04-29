using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateDiaryEntryDto
    {
        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        public required string Content { get; set; }

        [Required]
        [Range(1, 10)]
        public int MoodRating { get; set; }
    }
}