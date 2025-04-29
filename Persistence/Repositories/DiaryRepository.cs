using Application.Interfaces;
using Domain.Entities;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class DiaryRepository : IDiaryRepository
    {
        private readonly MoodMateDbContext _context;

        public DiaryRepository(MoodMateDbContext context)
        {
            _context = context;
        }

        public async Task AddEntryAsync(DiaryEntry entry)
        {
            await _context.DiaryEntries.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DiaryEntry>> GetEntriesByUserIdAsync(int userId)
        {
            return await _context.DiaryEntries
                .Where(e => e.UserId == userId)
                .OrderBy(e => e.EntryDate)
                .ToListAsync();
        }
    }
}
