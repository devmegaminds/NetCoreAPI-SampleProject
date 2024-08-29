using UI_UX_Targeting_api.DataModel;

namespace UI_UX_Targeting_api.BusinessServices
{
    /// <summary>
    /// Defines the contract for user-related operations.
    /// </summary>
    public partial interface IUserService
    {
        /// <summary>
        /// Retrieves all user information from the database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a list of all user information records.
        /// </returns>
        Task<IList<UserInfo>> GetAllUserInfoAsync();

        /// <summary>
        /// Retrieves user information by the user's unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the user information record with the specified identifier.
        /// </returns>
        Task<UserInfo> GetUserByIdAsync(int userId);

        /// <summary>
        /// Marks a user as deleted in the database.
        /// </summary>
        /// <param name="user">The user information record to be deleted.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task DeleteUserAsync(UserInfo user);

        /// <summary>
        /// Inserts a new user into the database.
        /// </summary>
        /// <param name="user">The user information record to be inserted.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task InsertUserAsync(UserInfo user);

        /// <summary>
        /// Updates an existing user's information in the database.
        /// </summary>
        /// <param name="user">The user information record with updated values.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task UpdateUserAsync(UserInfo user);

        /// <summary>
        /// Authenticates a user based on the provided email and password.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the authenticated user information if authentication is successful; otherwise, <c>null</c>.
        /// </returns>
        Task<UserInfo> AuthenticateAsync(string email, string password);
    }
}