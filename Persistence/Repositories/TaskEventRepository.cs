using Application.Interfaces;
using Domain.Entities;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class TaskEventRepository : ITaskEventRepository
    {
        private readonly MoodMateDbContext _context;

        public TaskEventRepository(MoodMateDbContext context)
        {
            _context = context;
        }

        public async Task AddEventAsync(TaskEvent taskEvent)
        {
            await _context.TaskEvents.AddAsync(taskEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskEvent>> GetUpcomingEventsByUserIdAsync(int userId)
        {
            return await _context.TaskEvents
                .Where(e => e.UserId == userId && e.EventDate >= DateTime.Today)
                .OrderBy(e => e.EventDate)
                .ToListAsync();
        }
    }
}
