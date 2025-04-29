using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AppUser
    {
        public AppUser()
        {
            DiaryEntries = new List<DiaryEntry>();
            Tasks = new List<UserTask>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
        public ICollection<DiaryEntry> DiaryEntries { get; set; }
        public ICollection<UserTask> Tasks { get; set; }
    }
}