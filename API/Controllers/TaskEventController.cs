using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Only logged-in users can access
    public class TaskEventController : ControllerBase
    {
        private readonly ITaskEventService _taskEventService;
        private readonly IMapper _mapper;

        public TaskEventController(ITaskEventService taskEventService, IMapper mapper)
        {
            _taskEventService = taskEventService;
            _mapper = mapper;
        }

        // POST: api/TaskEvent
        [HttpPost]
        public async Task<IActionResult> CreateTaskEvent([FromBody] TaskEventDTO taskEventDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTaskEvent = await _taskEventService.CreateTaskEventAsync(taskEventDTO);
            return Ok(createdTaskEvent);
        }

        // GET: api/TaskEvent
        [HttpGet]
        public async Task<IActionResult> GetAllTaskEvents()
        {
            var taskEvents = await _taskEventService.GetAllTaskEventsAsync();
            return Ok(taskEvents);
        }

        // GET: api/TaskEvent/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskEventById(int id)
        {
            var taskEvent = await _taskEventService.GetTaskEventByIdAsync(id);
            if (taskEvent == null)
                return NotFound();

            return Ok(taskEvent);
        }

        // PUT: api/TaskEvent/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskEvent(int id, [FromBody] TaskEventDTO taskEventDTO)
        {
            if (id != taskEventDTO.Id)
                return BadRequest("ID mismatch");

            var result = await _taskEventService.UpdateTaskEventAsync(taskEventDTO);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/TaskEvent/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskEvent(int id)
        {
            var result = await _taskEventService.DeleteTaskEventAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
