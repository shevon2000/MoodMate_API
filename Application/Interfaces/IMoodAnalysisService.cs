using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMoodAnalysisService
    {
        Task<Dictionary<DateTime, int>> GetMoodTrendByDateRange(Guid userId, DateTime startDate, DateTime endDate);
        Task<double> GetAverageMoodRating(Guid userId, DateTime startDate, DateTime endDate);
    }
}