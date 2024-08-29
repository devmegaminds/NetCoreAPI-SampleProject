using UI_UX_Targeting_api.BusinessRepository;
using UI_UX_Targeting_api.DataModel;

namespace UI_UX_Targeting_api.BusinessServices
{
    /// <summary>
    /// Service for managing user-related operations.
    /// </summary>
    public partial class UserService : IUserService
    {
        #region Fields

        /// <summary>
        /// Repository for performing CRUD operations on user data.
        /// </summary>
        protected readonly IRepository<UserInfo> _userRepository;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The repository to be used for accessing user data.</param>
        public UserService(IRepository<UserInfo> userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves all user information from the database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a list of all user information records.
        /// </returns>
        public virtual async Task<IList<UserInfo>> GetAllUserInfoAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the user information if found; otherwise, <c>null</c>.
        /// </returns>
        public virtual async Task<UserInfo> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        /// <summary>
        /// Deletes a user from the database.
        /// </summary>
        /// <param name="user">The user information to be deleted.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        public virtual async Task DeleteUserAsync(UserInfo user)
        {
            await _userRepository.DeleteAsync(user);
        }

        /// <summary>
        /// Inserts a new user into the database.
        /// </summary>
        /// <param name="user">The user information to be inserted.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        public virtual async Task InsertUserAsync(UserInfo user)
        {
            await _userRepository.InsertAsync(user);
        }

        /// <summary>
        /// Updates an existing user's information in the database.
        /// </summary>
        /// <param name="user">The user information with updated values.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        public virtual async Task UpdateUserAsync(UserInfo user)
        {
            await _userRepository.UpdateAsync(user);
        }

        /// <summary>
        /// Authenticates a user based on the provided email and password.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the authenticated user information if authentication is successful; otherwise, <c>null</c>.
        /// </returns>
        public async Task<UserInfo> AuthenticateAsync(string email, string password)
        {
            // Retrieve user from the database
            var user = (await _userRepository.GetAllAsync()).SingleOrDefault(x => x.Email == email && x.Password == password);

            // Check if user exists
            if (user == null)
                return null;

            // Return user if authentication is successful
            return user;
        }

        #endregion
    }
}
