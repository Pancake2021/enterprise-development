using UniversityStats.Domain.Entity;

namespace UniversityStats.Domain.Repositories
{
    /// <summary>
    /// Interface for the repository of objects of type <typeparamref name="T"/>.
    /// Defines methods for CRUD (Create, Read, Update, Delete) operations.
    /// </summary>
    /// <typeparam name="T">The type of object managed by the repository.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Retrieves all objects of type <typeparamref name="T"/> from the database.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> collection containing all objects of type <typeparamref name="T"/>.</returns>
        public IEnumerable<T> GetAll();

        /// <summary>
        /// Retrieves an object of type <typeparamref name="T"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the object to retrieve.</param>
        /// <returns>The object of type <typeparamref name="T"/> if found; otherwise, <c>null</c>.</returns>
        public T? GetById(string id);

        /// <summary>
        /// Adds an object of type <typeparamref name="T"/> to the database.
        /// </summary>
        /// <param name="data">The object of type <typeparamref name="T"/> to add.</param>
        public void Post(T data);

        /// <summary>
        /// Updates an existing object of type <typeparamref name="T"/> with new data.
        /// </summary>
        /// <param name="data">The updated data for the object of type <typeparamref name="T"/>.</param>
        /// <returns><c>true</c> if the object was successfully updated; otherwise, <c>false</c>.</returns>
        public bool Put(T data);

        /// <summary>
        /// Deletes an object of type <typeparamref name="T"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the object to delete.</param>
        /// <returns><c>true</c> if the object was successfully deleted; otherwise, <c>false</c>.</returns>
        public bool Delete(string id);
    }
}
