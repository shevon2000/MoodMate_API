using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Controllers;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Authorize]
    public class DiaryEntriesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IDiaryFileService _diaryFileService;
        private readonly IMoodAnalysisService _moodAnalysisService;

        public DiaryEntriesController(DataContext context, IDiaryFileService diaryFileService, IMoodAnalysisService moodAnalysisService)
        {
            _context = context;
            _diaryFileService = diaryFileService;
            _moodAnalysisService = moodAnalysisService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DiaryEntryDto>>> GetUserDiaryEntries()
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();

            var entries = await _context.DiaryEntries
                .Where(e => e.AppUserId == userId.Value)
                .OrderByDescending(e => e.EntryDate)
                .ToListAsync();

            return entries.Select(e => new DiaryEntryDto
            {
                Id = e.Id,
                EntryDate = e.EntryDate,
                Content = e.Content,
                MoodRating = e.MoodRating,
                FilePath = e.FilePath
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiaryEntryDto>> GetDiaryEntry(Guid id)
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();

            var entry = await _context.DiaryEntries
                .FirstOrDefaultAsync(e => e.Id == id && e.AppUserId == userId.Value);

            if (entry == null) return NotFound();

            return new DiaryEntryDto
            {
                Id = entry.Id,
                EntryDate = entry.EntryDate,
                Content = entry.Content,
                MoodRating = entry.MoodRating,
                FilePath = entry.FilePath
            };
        }

        [HttpGet("file/{id}")]
        public async Task<ActionResult<string>> GetDiaryEntryFile(Guid id)
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();

            var entry = await _context.DiaryEntries
                .FirstOrDefaultAsync(e => e.Id == id && e.AppUserId == userId.Value);

            if (entry == null) return NotFound();

            var fileContent = await _diaryFileService.ReadDiaryEntryFromFile(entry.FilePath);
            if (fileContent == null) return NotFound("File not found");

            return fileContent;
        }

        [HttpPost]
        public async Task<ActionResult<DiaryEntryDto>> CreateDiaryEntry(CreateDiaryEntryDto createDto)
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();
            
            // Save to file system
            var filePath = await _diaryFileService.SaveDiaryEntryToFile(
                userId.Value, 
                createDto.EntryDate, 
                createDto.MoodRating, 
                createDto.Content
            );

            // Create database entry
            var diaryEntry = new DiaryEntry
            {
                Id = Guid.NewGuid(),
                EntryDate = createDto.EntryDate,
                Content = createDto.Content,
                MoodRating = createDto.MoodRating,
                FilePath = filePath,
                AppUserId = userId.Value
            };

            _context.DiaryEntries.Add(diaryEntry);
            await _context.SaveChangesAsync();

            return new DiaryEntryDto
            {
                Id = diaryEntry.Id,
                EntryDate = diaryEntry.EntryDate,
                Content = diaryEntry.Content,
                MoodRating = diaryEntry.MoodRating,
                FilePath = diaryEntry.FilePath
            };
        }

        [HttpGet("mood-trend")]
        public async Task<ActionResult<Dictionary<DateTime, int>>> GetMoodTrend(
            [FromQuery] DateTime startDate, 
            [FromQuery] DateTime endDate)
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();

            var result = await _moodAnalysisService.GetMoodTrendByDateRange(userId.Value, startDate, endDate);
            return result;
        }

        [HttpGet("average-mood")]
        public async Task<ActionResult<double>> GetAverageMood(
            [FromQuery] DateTime startDate, 
            [FromQuery] DateTime endDate)
        {
            var userId = GetUserId();
            if (!userId.HasValue) return Unauthorized();

            var result = await _moodAnalysisService.GetAverageMoodRating(userId.Value, startDate, endDate);
            return result;
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