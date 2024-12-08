using UniversityStats.API;
using UniversityStats.API.Services;
using UniversityStats.API.Dto;
using UniversityStats.Domain.Entity;
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

builder.Services.AddSingleton<IRepository<Department>, DepartmentRepository>();
builder.Services.AddSingleton<IRepository<University>, UniversityRepository>();
builder.Services.AddSingleton<IRepository<Faculty>, FacultyRepository>();
builder.Services.AddSingleton<IRepository<DepartmentSpecialty>, DepartmentSpecialtyRepository>();
builder.Services.AddSingleton<IRepository<Specialty>, SpecialtyRepository>();
builder.Services.AddSingleton<QueryRepository>();

builder.Services.AddSingleton<IService<DepartmentDto>, DepartmentService>();
builder.Services.AddSingleton<IService<UniversityDto>, UniversityService>();
builder.Services.AddSingleton<IService<FacultyDto>, FacultyService>();
builder.Services.AddSingleton<IService<DepartmentSpecialtyDto>, DepartmentSpecialtyService>();
builder.Services.AddSingleton<IService<SpecialtyDto>, SpecialtyService>();
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
