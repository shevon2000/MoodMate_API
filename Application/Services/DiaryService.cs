using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using System.Text;
using System.Text.RegularExpressions;

namespace Application.Services
{
    public class DiaryService
    {
        private readonly IDiaryRepository _diaryRepository;

        public DiaryService(IDiaryRepository diaryRepository)
        {
            _diaryRepository = diaryRepository;
        }

        public async Task AddEntryAsync(int userId, string mood, string thoughts)
        {
            var entry = new DiaryEntry
            {
                UserId = userId,
                EntryDate = DateTime.UtcNow, // Save with UTC to avoid time zone issues
                Mood = mood,
                Thoughts = thoughts
            };

            await _diaryRepository.AddEntryAsync(entry);

            SaveLocally(entry);
        }

        public async Task<List<DiaryEntry>> GetEntriesAsync(int userId)
        {
            return await _diaryRepository.GetEntriesByUserIdAsync(userId);
        }

        private void SaveLocally(DiaryEntry entry)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "DiaryEntries");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName = $"{entry.EntryDate:yyyy-MM-dd_HH-mm-ss}.txt";
            var fullPath = Path.Combine(folderPath, fileName);

            using (var file = new StreamWriter(fullPath))
            {
                file.WriteLine($"Date: {entry.EntryDate:yyyy-MM-dd HH:mm:ss}");
                file.WriteLine($"Mood: {entry.Mood}");
                file.WriteLine("Thoughts:");
                file.WriteLine(entry.Thoughts);
            }
        }

        public async Task<List<MoodRecordDTO>> GetMoodRecordsAsync(int userId)
        {
            var entries = await _diaryRepository.GetEntriesByUserIdAsync(userId);

            var moodRecords = new List<MoodRecordDTO>();

            foreach (var entry in entries)
            {
                int moodScore = ExtractMoodScore(entry.Mood);
                
                moodRecords.Add(new MoodRecordDTO
                {
                    Date = entry.EntryDate,
                    MoodScore = moodScore
                });
            }

            return moodRecords;
        }

        // Helper method
        private int ExtractMoodScore(string moodText)
        {
            // Assume mood is like "7/10", "8/10" etc.
            var match = Regex.Match(moodText, @"(\d+)/10");

            if (match.Success)
            {
                return int.Parse(match.Groups[1].Value);
            }

            return 0; // default if mood parsing failed
        }
    }
}
