namespace UI_UX_Targeting_api.DataModel
{
    /// <summary>
    /// Represents user information in the application.
    /// </summary>
    public partial class UserInfo : BaseEntity
    {
        /// <summary>
        /// Gets or sets the display name of the user.
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the username for the user.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the password for the user's account.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user account was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }
    }
}
