using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UI_UX_Targeting_api.BusinessServices;
using UI_UX_Targeting_api.DataModel;

namespace UI_UX_Targeting_api.Controllers
{
    /// <summary>
    /// Controller for managing user-related actions.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">Service to handle user operations.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="userInfo">The user information to be added.</param>
        /// <returns>An action result indicating the success of the operation.</returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Add a new user",
            Description = "Creates a new user record with the provided information."
        )]
        public async Task<IActionResult> AddUserInfo([FromBody] UserInfo userInfo)
        {
            await _userService.InsertUserAsync(userInfo);
            return Ok();
        }

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="userInfo">The updated user information.</param>
        /// <returns>An action result indicating the success of the operation.</returns>
        [Authorize]
        [HttpPut]
        [SwaggerOperation(
            Summary = "Update existing user",
            Description = "Updates an existing user record with the provided information."
        )]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserInfo userInfo)
        {
            await _userService.UpdateUserAsync(userInfo);
            return Ok();
        }

        /// <summary>
        /// Deletes a user based on their ID.
        /// </summary>
        /// <param name="id">The ID of the user to be deleted.</param>
        /// <returns>An action result indicating the success of the operation.</returns>
        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a user",
            Description = "Deletes a user record identified by the provided ID."
        )]
        public async Task<IActionResult> DeleteUserInfo(int id)
        {
            var userInfo = await _userService.GetUserByIdAsync(id);
            await _userService.DeleteUserAsync(userInfo);
            return Ok();
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An action result containing the user information.</returns>
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get user by ID",
            Description = "Retrieves a user record based on the provided ID."
        )]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userInfo = await _userService.GetUserByIdAsync(id);
            return Ok(userInfo);
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>An action result containing a list of all users.</returns>
        [Authorize]
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all users",
            Description = "Retrieves all user records."
        )]
        public async Task<IActionResult> GetAllUserInfo()
        {
            var userInfo = await _userService.GetAllUserInfoAsync();
            return Ok(userInfo);
        }
    }
}
