using BeneExApp.Data;
using BeneExApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BeneExApp.Repository
{
    /// <summary>
    /// This class implements the IExpenditureRepository interface to manage expenditure data.
    /// </summary>
    public class ExpenditureRepository : IExpenditureRepository
    {
        #region Fields

        private readonly BeneExAppContext _dbContext;

        #endregion

        #region Constructor

        public ExpenditureRepository(BeneExAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method retrieves all expenditures from the database.
        /// </summary>
        ///<returns>A task that represents the asynchronous operation, containing a list of expenditures.</returns>
        public async Task<List<Expenditure>> GetAllAsync()
        {
            var expenditures = await _dbContext.Expenditures.Include(b => b.Beneficiary).ToListAsync();
            return expenditures;
        }

        /// <summary>
        /// Retrieves a expenditure by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the expenditure to retrieve.</param>
        /// <returns>A expenditure object representing the expenditure with the specified ID, or null if no such expenditure exists.</returns>
        public async Task<Expenditure?> GetAsync(int id)
        {
            var expenditure = await _dbContext.Expenditures.Include(b => b.Beneficiary).FirstOrDefaultAsync(x => x.Id == id);
            if (expenditure == null)
            {
                return null;
            }
            return expenditure;
        }

        /// <summary>
        /// Asynchronously adds a new expenditure entity to the data context.
        /// </summary>
        /// <param name="entity">The expenditure entity to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added expenditure entity.</returns>
        public async Task<Expenditure> AddAsync(Expenditure entity)
        {
            var expenditure = await _dbContext.Expenditures.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Updates the specified expenditure entity in the database.
        /// </summary>
        /// <param name="entity">The expenditure entity to update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated expenditure entity.</returns>
        public Task<Expenditure> UpdateAsync(Expenditure entity)
        {
            var expenditure = _dbContext.Expenditures.Update(entity);
            return Task.FromResult(entity);
        }

        /// <summary>
        /// Saves all changes made in the current context to the database asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}