using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly MoodMateDbContext _context;

        public EventRepository(MoodMateDbContext context)
        {
            _context = context;
        }

        public async Task AddEventAsync(Event ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Event>> GetEventsByUserIdAsync(int userId)
        {
            return await _context.Events
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.EventDate)
                .ToListAsync();
        }
    }
}
