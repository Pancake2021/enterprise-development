using UniversityStats.Domain.Entity;

namespace UniversityStats.Domain.Repositories
{
    /// <summary>
    /// Repository for managing operations related to the Department entity.
    /// Implements the <see cref="IRepository{Department}"/> interface.
    /// </summary>
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentRepository"/> class.
        /// </summary>
        /// <param name="database">The database instance to interact with.</param>
        public DepartmentRepository(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// Deletes a Department by its ID.
        /// If the department is found, it will be removed from the list.
        /// </summary>
        /// <param name="id">The ID of the department to delete.</param>
        /// <returns>
        /// <c>true</c> if the department was successfully deleted; otherwise, <c>false</c>.
        /// </returns>
        public bool Delete(string id)
        {
            var value = GetById(id);

            // If the department is not found, return false.
            if (value == null)
                return false;

            // Remove the department from the list.
            database.DepartmentsList.Remove(value);

            return true;
        }

        /// <summary>
        /// Retrieves all departments from the database.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Department}"/> of all departments.</returns>
        public IEnumerable<Department> GetAll()
        {
            return database.DepartmentsList;
        }

        /// <summary>
        /// Retrieves a department by its ID.
        /// </summary>
        /// <param name="id">The ID of the department to retrieve.</param>
        /// <returns>
        /// A <see cref="Department"/> object if found; otherwise, <c>null</c>.
        /// </returns>
        public Department? GetById(string id)
        {
            return database.DepartmentsList.Find(a => a.DepartmentId == id);
        }

        /// <summary>
        /// Adds a new department to the database.
        /// </summary>
        /// <param name="data">The department data to add.</param>
        public void Post(Department data)
        {
            database.DepartmentsList.Add(data);
        }

        /// <summary>
        /// Updates an existing department with new data.
        /// </summary>
        /// <param name="data">The updated department data.</param>
        /// <returns>
        /// <c>true</c> if the department was successfully updated; otherwise, <c>false</c>.
        /// </returns>
        public bool Put(Department data)
        {
            var oldValue = GetById(data.DepartmentId);

            // If the department to update is not found, return false.
            if (oldValue == null)
                return false;

            // Update the department's properties.
            oldValue.NameDepartment = data.NameDepartment;
            oldValue.DepartmentId = data.DepartmentId;
            oldValue.FacultyId = data.FacultyId;

            return true;
        }
    }
}
