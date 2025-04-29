using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Authorize]
    public class HelpResourcesController : BaseApiController
    {
        private readonly DataContext _context;

        public HelpResourcesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HelpResourceDto>>> GetAllResources()
        {
            var resources = await _context.HelpResources
                .OrderBy(r => r.Category)
                .ToListAsync();

            return resources.Select(r => new HelpResourceDto
            {
                Id = r.Id,
                Title = r.Title,
                Content = r.Content,
                Category = r.Category
            }).ToList();
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<string>>> GetCategories()
        {
            var categories = await _context.HelpResources
                .Select(r => r.Category)
                .Distinct()
                .ToListAsync();

            return categories;
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<List<HelpResourceDto>>> GetResourcesByCategory(string category)
        {
            var resources = await _context.HelpResources
                .Where(r => r.Category == category)
                .ToListAsync();

            return resources.Select(r => new HelpResourceDto
            {
                Id = r.Id,
                Title = r.Title,
                Content = r.Content,
                Category = r.Category
            }).ToList();
        }
    }
}