using UniversityStats.Domain.Entity;

namespace UniversityStats.Domain.Repositories;


    /// <summary>
    /// Repository for handling operations related to DepartmentSpecialty.
    /// Implements the <see cref="IRepository{DepartmentSpecialty}"/> interface.
    /// </summary>
    public class DepartmentSpecialtyRepository : IRepository<DepartmentSpecialty>
    {
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentSpecialtyRepository"/> class.
        /// </summary>
        /// <param name="database">The database instance to interact with.</param>
        public DepartmentSpecialtyRepository(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// Deletes a DepartmentSpecialty by its ID.
        /// If the specialty is found, it will be removed from the database.
        /// </summary>
        /// <param name="id">The ID of the DepartmentSpecialty to delete.</param>
        /// <returns>
        /// <c>true</c> if the DepartmentSpecialty was deleted successfully; otherwise, <c>false</c>.
        /// </returns>
        public bool Delete(string id)
        {
            var value = GetById(id);

            // If the specialty is not found, return false.
            if (value == null)
                return false;

            // Remove the specialty from the list.
            database.DepartmentSpecialtyList.Remove(value);

            return true;
        }

        /// <summary>
        /// Retrieves all DepartmentSpecialties from the database.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{DepartmentSpecialty}"/> of all DepartmentSpecialties.</returns>
        public IEnumerable<DepartmentSpecialty> GetAll()
        {
            return database.DepartmentSpecialtyList;
        }

        /// <summary>
        /// Retrieves a DepartmentSpecialty by its ID.
        /// </summary>
        /// <param name="id">The ID of the DepartmentSpecialty to retrieve.</param>
        /// <returns>
        /// A <see cref="DepartmentSpecialty"/> object if found; otherwise, <c>null</c>.
        /// </returns>
        public DepartmentSpecialty? GetById(string id)
        {
            return database.DepartmentSpecialtyList.Find(a => a.SpecialtyId == id);
        }

        /// <summary>
        /// Adds a new DepartmentSpecialty to the database.
        /// </summary>
        /// <param name="data">The DepartmentSpecialty to add.</param>
        public void Post(DepartmentSpecialty data)
        {
            database.DepartmentSpecialtyList.Add(data);
        }

        /// <summary>
        /// Updates an existing DepartmentSpecialty in the database.
        /// </summary>
        /// <param name="data">The updated DepartmentSpecialty data.</param>
        /// <returns>
        /// <c>true</c> if the DepartmentSpecialty was updated successfully; otherwise, <c>false</c>.
        /// </returns>
        public bool Put(DepartmentSpecialty data)
        {
            var oldValue = GetById(data.SpecialtyId);

            // If the specialty to update is not found, return false.
            if (oldValue == null)
                return false;

            // Update the department and specialty IDs.
            oldValue.DepartmentId = data.DepartmentId;
            oldValue.SpecialtyId = data.SpecialtyId;

            return true;
        }
    }

