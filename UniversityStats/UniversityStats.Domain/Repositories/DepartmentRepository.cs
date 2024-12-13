using UniversityStats.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace UniversityStats.Domain.Repositories;

public class DepartmentRepository(UniversityStatsContext educationDepartmentContext) : IRepository<Department>
{
    public bool Delete(string registrationNumber)
    {
        var value = GetByRegistrationNumber(registrationNumber);

        if (value == null)
            return false;

        educationDepartmentContext.Department.Remove(value);
        educationDepartmentContext.SaveChanges();

        return true;
    }

    public IEnumerable<Department> GetAll() => educationDepartmentContext.Department;

    public Department? GetById(string id) => educationDepartmentContext.Department.FirstOrDefault(a => a.DepartmentId == id);

    public Department? GetByRegistrationNumber(string registrationNumber) => 
        educationDepartmentContext.Department.FirstOrDefault(d => d.RegistrationNumber == registrationNumber);

    public void Post(Department data)
    {
        educationDepartmentContext.Department.Add(data);
        educationDepartmentContext.SaveChanges();
    }

    public bool Put(Department data)
    {
        var oldValue = GetByRegistrationNumber(data.RegistrationNumber) ?? GetById(data.DepartmentId);

        if (oldValue == null)
            return false;

        educationDepartmentContext.Entry(oldValue).State = EntityState.Detached;

        educationDepartmentContext.Entry(data).State = EntityState.Modified;

        educationDepartmentContext.SaveChanges();

        return true;
    }
}
