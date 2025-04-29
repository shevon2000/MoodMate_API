using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Controllers;
using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Authorize]
    public class TasksController : BaseApiController
    {
        private readonly DataContext _context;

        public TasksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> GetUserTasks()
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();

            var tasks = await _context.Tasks
                .Where(t => t.AppUserId == userId.Value)
                .OrderBy(t => t.DueDate)
                .ToListAsync();

            return tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                IsCompleted = t.IsCompleted
            }).ToList();
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<List<TaskDto>>> GetUpcomingTasks()
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();

            var today = DateTime.Today;
            var weekFromNow = today.AddDays(7);
            
            var tasks = await _context.Tasks
                .Where(t => t.AppUserId == userId.Value && !t.IsCompleted && t.DueDate >= today && t.DueDate <= weekFromNow)
                .OrderBy(t => t.DueDate)
                .ToListAsync();

            return tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                IsCompleted = t.IsCompleted
            }).ToList();
        }

        [HttpGet("overdue")]
        public async Task<ActionResult<List<TaskDto>>> GetOverdueTasks()
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();

            var today = DateTime.Today;
            
            var tasks = await _context.Tasks
                .Where(t => t.AppUserId == userId.Value && !t.IsCompleted && t.DueDate < today)
                .OrderBy(t => t.DueDate)
                .ToListAsync();

            return tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                IsCompleted = t.IsCompleted
            }).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask(CreateTaskDto createDto)
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();
            
            var task = new UserTask
            {
                Id = Guid.NewGuid(),
                Title = createDto.Title,
                Description = createDto.Description ?? string.Empty,
                DueDate = createDto.DueDate,
                IsCompleted = false,
                IsNotified = false,
                AppUserId = userId.Value
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted
            };
        }

        [HttpPut("{id}/complete")]
        public async Task<ActionResult> CompleteTask(Guid id)
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();

            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id && t.AppUserId == userId.Value);

            if (task == null) return NotFound();

            task.IsCompleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private Guid? GetUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return null;
                
            return Guid.Parse(userId);
        }
    }
}