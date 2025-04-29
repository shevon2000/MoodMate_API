using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEventRepository
    {
        Task AddEventAsync(Event ev);
        Task<List<Event>> GetEventsByUserIdAsync(int userId);
    }
}
