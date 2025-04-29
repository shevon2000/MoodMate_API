using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services
{
    public class MoodAnalysisService : IMoodAnalysisService
    {
        private readonly DataContext _context;

        public MoodAnalysisService(DataContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<DateTime, int>> GetMoodTrendByDateRange(Guid userId, DateTime startDate, DateTime endDate)
        {
            var entries = await _context.DiaryEntries
                .Where(e => e.AppUserId == userId && e.EntryDate >= startDate && e.EntryDate <= endDate)
                .OrderBy(e => e.EntryDate)
                .ToListAsync();

            return entries.ToDictionary(e => e.EntryDate.Date, e => e.MoodRating);
        }

        public async Task<double> GetAverageMoodRating(Guid userId, DateTime startDate, DateTime endDate)
        {
            var entries = await _context.DiaryEntries
                .Where(e => e.AppUserId == userId && e.EntryDate >= startDate && e.EntryDate <= endDate)
                .ToListAsync();

            if (!entries.Any())
                return 0;

            return entries.Average(e => e.MoodRating);
        }
    }
}