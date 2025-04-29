using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        public required string Title { get; set; }

        public required string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}