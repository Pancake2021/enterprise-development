using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Repositories.Interfaces;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for department's service
/// </summary>
public class DepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    /// <summary>
    /// Constructor for DepartmentService
    /// </summary>
    /// <param name="departmentRepository">Department's repository</param>
    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// Method get department by department's id
    /// </summary>
    /// <param name="id">Department's id</param>
    /// <returns>Department's information or null</returns>
    public async Task<Department?> GetDepartmentByIdAsync(int id)
    {
        return await _departmentRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Method get list of departments
    /// </summary>
    /// <returns>List of departments</returns>
    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
    {
        return await _departmentRepository.GetAllAsync();
    }

    /// <summary>
    /// Method post department to database
    /// </summary>
    /// <param name="department">Department's information</param>
    /// <returns>Department's information</returns>
    public async Task<Department> CreateDepartmentAsync(Department department)
    {
        return await _departmentRepository.AddAsync(department);
    }

    /// <summary>
    /// Method put department by department's id
    /// </summary>
    /// <param name="department">Department's information</param>
    /// <returns>Department's information</returns>
    public async Task<Department> UpdateDepartmentAsync(Department department)
    {
        return await _departmentRepository.UpdateAsync(department);
    }

    /// <summary>
    /// Method delete department by department's id
    /// </summary>
    /// <param name="id">Department's id</param>
    /// <returns>True or False</returns>
    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        return await _departmentRepository.DeleteAsync(id);
    }
}
