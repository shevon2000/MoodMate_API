using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITaskEventRepository
    {
        Task AddEventAsync(TaskEvent taskEvent);
        Task<List<TaskEvent>> GetUpcomingEventsByUserIdAsync(int userId);
    }
}
