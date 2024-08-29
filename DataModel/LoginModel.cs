using System.ComponentModel.DataAnnotations;

namespace UI_UX_Targeting_api.DataModel
{
    /// <summary>
    /// Represents the data required for user login.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        /// <remarks>
        /// This field is required for login and will display an error message if left empty.
        /// </remarks>
        [Required(ErrorMessage = "User Name is required")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        /// <remarks>
        /// This field is required for login and will display an error message if left empty.
        /// </remarks>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
