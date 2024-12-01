using UniversityStats.Domain.Entity;

namespace UniversityStats.Domain.Repositories
{
    /// <summary>
    /// Repository for managing operations related to the Faculty entity.
    /// Implements the <see cref="IRepository{Faculty}"/> interface.
    /// </summary>
    public class FacultyRepository : IRepository<Faculty>
    {
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacultyRepository"/> class.
        /// </summary>
        /// <param name="database">The database instance to interact with.</param>
        public FacultyRepository(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// Deletes a Faculty by its ID.
        /// If the faculty is found, it will be removed from the list.
        /// </summary>
        /// <param name="id">The ID of the faculty to delete.</param>
        /// <returns>
        /// <c>true</c> if the faculty was successfully deleted; otherwise, <c>false</c>.
        /// </returns>
        public bool Delete(string id)
        {
            var value = GetById(id);

            // If the faculty is not found, return false.
            if (value == null)
                return false;

            // Remove the faculty from the list.
            database.FacultyList.Remove(value);

            return true;
        }

        /// <summary>
        /// Retrieves all faculties from the database.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Faculty}"/> of all faculties.</returns>
        public IEnumerable<Faculty> GetAll()
        {
            return database.FacultyList;
        }

        /// <summary>
        /// Retrieves a faculty by its ID.
        /// </summary>
        /// <param name="id">The ID of the faculty to retrieve.</param>
        /// <returns>
        /// A <see cref="Faculty"/> object if found; otherwise, <c>null</c>.
        /// </returns>
        public Faculty? GetById(string id)
        {
            return database.FacultyList.Find(a => a.FacultyId == id);
        }

        /// <summary>
        /// Adds a new faculty to the database.
        /// </summary>
        /// <param name="data">The faculty data to add.</param>
        public void Post(Faculty data)
        {
            database.FacultyList.Add(data);
        }

        /// <summary>
        /// Updates an existing faculty with new data.
        /// </summary>
        /// <param name="data">The updated faculty data.</param>
        /// <returns>
        /// <c>true</c> if the faculty was successfully updated; otherwise, <c>false</c>.
        /// </returns>
        public bool Put(Faculty data)
        {
            var oldValue = GetById(data.FacultyId);

            // If the faculty to update is not found, return false.
            if (oldValue == null)
                return false;

            // Update the faculty's properties.
            oldValue.FacultyId = data.FacultyId;
            oldValue.NameFaculty = data.NameFaculty;
            oldValue.RegistrationNumber = data.RegistrationNumber;

            return true;
        }
    }
}
