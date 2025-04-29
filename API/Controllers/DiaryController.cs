using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.DTOs;
using Domain.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiaryController : ControllerBase
    {
        private readonly DiaryService _diaryService;

        public DiaryController(DiaryService diaryService)
        {
            _diaryService = diaryService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEntry([FromBody] DiaryEntryDTO request)
        {
            await _diaryService.AddEntryAsync(request.UserId, request.Mood, request.Thoughts);
            return Ok("Entry saved successfully");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetEntries(int userId)
        {
            var entries = await _diaryService.GetEntriesAsync(userId);
            return Ok(entries);
        }

        [HttpGet("mood-visualization/{userId}")]
        public async Task<IActionResult> GetMoodVisualization(int userId)
        {
            var moodRecords = await _diaryService.GetMoodRecordsAsync(userId);
            return Ok(moodRecords);
        }

    }
}
