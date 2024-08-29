using UI_UX_Targeting_api.DataModel;

namespace UI_UX_Targeting_api.BusinessRepository
{
    /// <summary>
    /// Represents an entity repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Methods


        /// <summary>
        /// Get the entity entry
        /// </summary>
        /// <param name="id">Entity entry identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the entity entry
        /// </returns>
        Task<TEntity> GetByIdAsync(int? id);

        /// <summary>
        /// Get all entity entries
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the entity entries
        /// </returns>
        Task<IList<TEntity>> GetAllAsync();

        /// <summary>
        /// Insert the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Update the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Delete the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteAsync(TEntity entity);

        #endregion

    }
}
