using UniversityStats.API;
using UniversityStats.API.Services;
using UniversityStats.API.Services.Interfaces;
using UniversityStats.Domain;
using UniversityStats.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<UniversityStatsContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(UniversityStats));
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));
    
    options.UseMySql(connectionString, serverVersion, 
        mysqlOptions => 
        {
            mysqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        })
    #if DEBUG
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
    #endif
    ;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<UniversityRepository>();
builder.Services.AddScoped<FacultyRepository>();
builder.Services.AddScoped<DepartmentSpecialtyRepository>();
builder.Services.AddScoped<SpecialtyRepository>();
builder.Services.AddScoped<QueryRepository>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<ISpecialtyService, SpecialtyService>();
builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddScoped<IDepartmentSpecialtyService, DepartmentSpecialtyService>();
builder.Services.AddScoped<IQueryService, QueryService>();

builder.Services.AddScoped<DatabaseSeeder>();

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
