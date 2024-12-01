using UniversityStats.Domain.Entity;

namespace UniversityStats.Domain.Repositories
{
    /// <summary>
    /// Repository class for managing university-related data operations.
    /// Implements methods for CRUD operations on the University entity.
    /// </summary>
    public class UniversityRepository : IRepository<University>
    {
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityRepository"/> class with the specified database.
        /// </summary>
        /// <param name="database">The database object used to perform operations on the University entity.</param>
        public UniversityRepository(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// Deletes a university by its registration number.
        /// </summary>
        /// <param name="id">The registration number of the university to delete.</param>
        /// <returns>True if the university was deleted successfully; otherwise, false.</returns>
        public bool Delete(string id)
        {
            var value = GetById(id);

            if (value == null)
                return false;

            database.UniversityList.Remove(value);

            return true;
        }

        /// <summary>
        /// Gets all universities in the database.
        /// </summary>
        /// <returns>An enumerable collection of all universities.</returns>
        public IEnumerable<University> GetAll() => database.UniversityList;

        /// <summary>
        /// Gets a university by its registration number.
        /// </summary>
        /// <param name="id">The registration number of the university to retrieve.</param>
        /// <returns>The university with the specified registration number, or null if no university is found.</returns>
        public University? GetById(string id) => database.UniversityList.Find(a => a.RegistrationNumber == id);

        /// <summary>
        /// Adds a new university to the database.
        /// </summary>
        /// <param name="data">The university to add.</param>
        public void Post(University data)
        {
            database.UniversityList.Add(data);
        }

        /// <summary>
        /// Updates an existing university in the database.
        /// </summary>
        /// <param name="data">The university with updated information.</param>
        /// <returns>True if the university was updated successfully; otherwise, false.</returns>
        public bool Put(University data)
        {
            var oldValue = GetById(data.RegistrationNumber);

            if (oldValue == null)
                return false;

            oldValue.RegistrationNumber = data.RegistrationNumber;
            oldValue.Address = data.Address;
            oldValue.NameUniversity = data.NameUniversity;
            oldValue.RectorFullName = data.RectorFullName;
            oldValue.Tittle = data.Tittle;
            oldValue.BuildingOwnership = data.BuildingOwnership;
            oldValue.Degree = data.Degree;
            oldValue.PropertyType = data.PropertyType;

            return true;
        }
    }
}
