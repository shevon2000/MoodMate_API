using System;
using System.IO;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class DiaryFileService : IDiaryFileService
    {
        private readonly string _basePath;

        public DiaryFileService(IConfiguration configuration)
        {
            _basePath = configuration["DiaryFilePath"] ?? Path.Combine(Directory.GetCurrentDirectory(), "DiaryEntries");
            
            // Ensure directory exists
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public async Task<string> SaveDiaryEntryToFile(Guid userId, DateTime date, int mood, string thoughts)
        {
            // Create user-specific directory
            var userDirectory = Path.Combine(_basePath, userId.ToString());
            if (!Directory.Exists(userDirectory))
            {
                Directory.CreateDirectory(userDirectory);
            }

            // Format date for filename
            var dateFormatted = date.ToString("yyyy-MM-dd");
            var filePath = Path.Combine(userDirectory, $"{dateFormatted}.txt");

            // Write content to file
            var content = $"Date: {dateFormatted}\n" +
                         $"Mood: {mood}/10\n" +
                         $"Thoughts:\n{thoughts}\n";

            await File.WriteAllTextAsync(filePath, content);

            return filePath;
        }

        public async Task<string> ReadDiaryEntryFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            return await File.ReadAllTextAsync(filePath);
        }
    }
}
