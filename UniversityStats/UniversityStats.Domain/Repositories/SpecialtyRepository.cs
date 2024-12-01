using UniversityStats.Domain.Entity;

namespace UniversityStats.Domain.Repositories
{
    /// <summary>
    /// Repository class for managing specialty-related data operations.
    /// Implements methods for CRUD operations on the Specialty entity.
    /// </summary>
    public class SpecialtyRepository : IRepository<Specialty>
    {
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialtyRepository"/> class with the specified database.
        /// </summary>
        /// <param name="database">The database object used to perform operations on the Specialty entity.</param>
        public SpecialtyRepository(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// Deletes a specialty by its ID.
        /// </summary>
        /// <param name="id">The ID of the specialty to delete.</param>
        /// <returns>True if the specialty was deleted successfully; otherwise, false.</returns>
        public bool Delete(string id)
        {
            var value = GetById(id);

            if (value == null)
                return false;

            database.SpecialtyList.Remove(value);

            return true;
        }

        /// <summary>
        /// Gets all specialties in the database.
        /// </summary>
        /// <returns>An enumerable collection of all specialties.</returns>
        public IEnumerable<Specialty> GetAll() => database.SpecialtyList;

        /// <summary>
        /// Gets a specialty by its ID.
        /// </summary>
        /// <param name="id">The ID of the specialty to retrieve.</param>
        /// <returns>The specialty with the specified ID, or null if no specialty is found.</returns>
        public Specialty? GetById(string id) => database.SpecialtyList.Find(a => a.SpecialtyId == id);

        /// <summary>
        /// Adds a new specialty to the database.
        /// </summary>
        /// <param name="data">The specialty to add.</param>
        public void Post(Specialty data)
        {
            database.SpecialtyList.Add(data);
        }

        /// <summary>
        /// Updates an existing specialty in the database.
        /// </summary>
        /// <param name="data">The specialty with updated information.</param>
        /// <returns>True if the specialty was updated successfully; otherwise, false.</returns>
        public bool Put(Specialty data)
        {
            var oldValue = GetById(data.SpecialtyId);

            if (oldValue == null)
                return false;

            oldValue.NameSpecialty = data.NameSpecialty;
            oldValue.SpecialtyId = data.SpecialtyId;
            oldValue.NumberOfGroups = data.NumberOfGroups;

            return true;
        }
    }
}
