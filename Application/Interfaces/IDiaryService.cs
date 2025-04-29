using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDiaryRepository
    {
        Task AddEntryAsync(DiaryEntry entry);
        Task<List<DiaryEntry>> GetEntriesByUserIdAsync(int userId);
    }
}
