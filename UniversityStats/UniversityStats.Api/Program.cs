using UniversityStats.API;
using UniversityStats.API.Services;
using UniversityStats.Domain.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DepartmentRepository>();
builder.Services.AddSingleton<UniversityRepository>();
builder.Services.AddSingleton<FacultyRepository>();
builder.Services.AddSingleton<DepartmentSpecialtyRepository>();
builder.Services.AddSingleton<SpecialtyRepository>();
builder.Services.AddSingleton<QueryRepository>();

builder.Services.AddSingleton<DepartmentService>();
builder.Services.AddSingleton<UniversityService>();
builder.Services.AddSingleton<FacultyService>();
builder.Services.AddSingleton<DepartmentSpecialtyService>();
builder.Services.AddSingleton<SpecialtyService>();
builder.Services.AddSingleton<QueryService>();

builder.Services.AddSingleton<Database>();

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

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
