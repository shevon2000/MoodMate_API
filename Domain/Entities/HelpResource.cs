using System;

namespace Domain.Entities
{
    public class HelpResource
    {
        public HelpResource()
        {
            Title = string.Empty;
            Content = string.Empty;
            Category = string.Empty;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; } // e.g., "Anger Management", "Stress Relief", etc.
    }
}