using Microsoft.Extensions.DependencyInjection;
using UniversityStats.Infrastructure.Repositories.Implementation;
using UniversityStats.Infrastructure.Repositories.Interfaces;

namespace UniversityStats.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUniversityRepository, UniversityRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IFacultyRepository, FacultyRepository>();
        services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        
        return services;
    }
}
