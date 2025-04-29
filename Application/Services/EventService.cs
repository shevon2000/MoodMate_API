using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task AddEventAsync(int userId, string title, string description, DateTime eventDate)
        {
            var ev = new Event
            {
                UserId = userId,
                Title = title,
                Description = description,
                EventDate = eventDate
            };

            await _eventRepository.AddEventAsync(ev);
        }

        public async Task<List<Event>> GetEventsAsync(int userId)
        {
            return await _eventRepository.GetEventsByUserIdAsync(userId);
        }
    }
}
