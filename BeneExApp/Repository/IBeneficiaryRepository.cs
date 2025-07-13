using BeneExApp.Domain;

namespace BeneExApp.Repository
{
    /// <summary>
    /// This is the IBeneficiaryRepository interface for managing beneficiary data operations.
    /// </summary>
    public interface IBeneficiaryRepository
    {
        /// <summary>
        /// Asynchronously retrieves a list of all beneficiaries.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of beneficiary objects, or an empty list if no beneficiaries are found.</returns>
        Task<List<Beneficiary>> GetAllAsync();

        /// <summary>
        /// Retrieves a beneficiary by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the beneficiary to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the beneficiary
        /// object  if found; otherwise, null.</returns>
        Task<Beneficiary?> GetAsync(int id);

        /// <summary>
        /// Asynchronously adds a new beneficiary to the database.
        /// </summary>
        /// <param name="entity">The beneficiary object to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added beneficiary object.</returns>
        Task<Beneficiary> AddAsync(Beneficiary entity);

        /// <summary>
        /// Updates the specified beneficiary entity in the database asynchronously.
        /// </summary>
        /// <param name="entity">The beneficiary entity to update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated beneficiary entity.</returns>
        Task<Beneficiary> UpdateAsync(Beneficiary entity);

        /// <summary>
        /// Saves the current state asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task Save();
    }
}
