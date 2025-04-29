using Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Persistence.Repositories;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add Database Connection
builder.Services.AddDbContext<MoodMateDbContext>(options =>
    options.UseInMemoryDatabase("MoodMateDb")); // or later use SQL Server

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDiaryRepository, DiaryRepository>();
builder.Services.AddScoped<ITaskEventRepository, TaskEventRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DiaryService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<HelpDeskService>();



var app = builder.Build();

// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();
