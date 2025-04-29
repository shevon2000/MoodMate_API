using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.DTOs;
using Domain.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEvent([FromBody] EventDTO request)
        {
            await _eventService.AddEventAsync(request.UserId, request.Title, request.Description, request.EventDate);
            return Ok("Event added successfully");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetEvents(int userId)
        {
            var events = await _eventService.GetEventsAsync(userId);
            return Ok(events);
        }
    }
}
