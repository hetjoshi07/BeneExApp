using BeneExApp.Data;
using BeneExApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BeneExApp.Repository
{
    /// <summary>
    /// This class implements the IBeneficiaryRepository interface to manage beneficiary data.
    /// </summary>
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        #region Fields

        private readonly BeneExAppContext _context;

        #endregion

        #region Constructor

        public BeneficiaryRepository(BeneExAppContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method retrieves all beneficiaries from the database.
        /// </summary>
        ///<returns>A task that represents the asynchronous operation, containing a list of beneficiaries.</returns>
        public async Task<List<Beneficiary>> GetAllAsync()
        {
            var beneficiaries = await _context.Beneficiaries.ToListAsync();
            return beneficiaries;
        }

        /// <summary>
        /// Retrieves a beneficiary by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the beneficiary to retrieve.</param>
        /// <returns>A beneficiary object representing the beneficiary with the specified ID, or null if no such beneficiary exists.</returns>
        public async Task<Beneficiary?> GetAsync(int id)
        {
            var beneficiary = await _context.Beneficiaries.Include(e => e.Expenditures).FirstOrDefaultAsync(b => b.Id == id);
            if (beneficiary == null)
            {
                return null;
            }
            return beneficiary;
        }

        /// <summary>
        /// Asynchronously adds a new beneficiary entity to the data context.
        /// </summary>
        /// <param name="entity">The beneficiary entity to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added beneficiary entity.</returns>
        public async Task<Beneficiary> AddAsync(Beneficiary entity)
        {
            var addedBeneficiary = await _context.Beneficiaries.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Updates the specified beneficiary entity in the database.
        /// </summary>
        /// <param name="entity">The beneficiary entity to update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated beneficiary entity.</returns>
        public Task<Beneficiary> UpdateAsync(Beneficiary entity)
        {
            var updatedBeneficiary = _context.Beneficiaries.Update(entity);
            return Task.FromResult(entity);
        }

        /// <summary>
        /// Saves all changes made in the current context to the database asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}