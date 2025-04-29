using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDiaryFileService
    {
        Task<string> SaveDiaryEntryToFile(Guid userId, DateTime date, int mood, string thoughts);
        Task<string> ReadDiaryEntryFromFile(string filePath);
    }
}