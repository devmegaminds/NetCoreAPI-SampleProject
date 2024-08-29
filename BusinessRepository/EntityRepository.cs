using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;
using UI_UX_Targeting_api.DataModel;

namespace UI_UX_Targeting_api.BusinessRepository
{
    /// <summary>
    /// Represents the entity repository implementation for CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity managed by the repository, must be derived from <see cref="BaseEntity"/>.</typeparam>
    public partial class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The database context used to interact with the database.</param>
        public EntityRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified identifier, or <c>null</c> if not found.</returns>
        public async Task<TEntity> GetByIdAsync(int? id)
        {
            if (!id.HasValue || id == 0)
                return null;

            IQueryable<TEntity> query = _dbSet;

            return await query.FirstOrDefaultAsync(e => e.Id == id.Value);
        }

        /// <summary>
        /// Retrieves all entities from the database.
        /// </summary>
        /// <returns>A list of all entities in the database.</returns>
        public async Task<IList<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = _dbSet;

            return await query.ToListAsync();
        }

        /// <summary>
        /// Inserts a new entity into the database.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InsertAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw; // Optional: Re-throw the exception to be handled by higher-level code
            }
        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity with updated values.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
