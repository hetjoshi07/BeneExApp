using BeneExApp.Domain;

namespace BeneExApp.Repository
{
    /// <summary>
    /// This is the IExpenditureRepository interface for managing expenditure data operations.
    /// </summary>
    public interface IExpenditureRepository
    {
        /// <summary>
        /// Method retrieves a list of all expenditures asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of expenditure objects, or an empty list if no expenditures are found.</returns>
        Task<List<Expenditure>> GetAllAsync();

        /// <summary>
        /// Retrieves a expenditure by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the expenditure to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the expenditure
        /// object  if found; otherwise, null.</returns>
        Task<Expenditure?> GetAsync(int id);

        /// <summary>
        /// Asynchronously adds a new expenditure to the database.
        /// </summary>
        /// <param name="entity">The expenditure object to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added expenditure object.</returns>
        Task<Expenditure> AddAsync(Expenditure entity);

        /// <summary>
        /// Updates the specified expenditure entity in the database asynchronously.
        /// </summary>
        /// <param name="entity">The expenditure entity to update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated expenditure entity.</returns>
        Task<Expenditure> UpdateAsync(Expenditure entity);

        /// <summary>
        /// Saves the current state asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveAsync();
    }
}