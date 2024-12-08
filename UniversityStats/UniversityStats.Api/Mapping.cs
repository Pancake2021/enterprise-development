using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.Domain.Entity;

namespace UniversityStats.API;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<DepartmentSpecialty, DepartmentSpecialtyDto>().ReverseMap();
        CreateMap<Faculty, FacultyDto>().ReverseMap();
        CreateMap<Specialty, SpecialtyDto>().ReverseMap();
        CreateMap<University, UniversityDto>().ReverseMap();
    }
}
