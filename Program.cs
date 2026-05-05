using JobApplicationAPI.Data;
using JobApplicationAPI.Services;
using Microsoft.EntityFrameworkCore;
using JobApplicationAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=devjobs.db"));

// 🔹 Service
builder.Services.AddScoped<IJobService, JobDatabaseService>();

// 🔹 Build
var app = builder.Build();

// 🔹 Middlewares
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();