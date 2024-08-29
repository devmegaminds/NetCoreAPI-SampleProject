using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UI_UX_Targeting_api.BusinessServices;
using UI_UX_Targeting_api.DataModel;

namespace UI_UX_Targeting_api.Controllers
{
    /// <summary>
    /// Controller responsible for handling authentication-related actions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="userService">Service to handle user operations.</param>
        /// <param name="jwtSettings">Settings for JWT token generation.</param>
        public AuthController(IUserService userService, IOptions<JwtSettings> jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Authenticates the user and generates a JWT token.
        /// </summary>
        /// <param name="loginModel">The login model containing user credentials.</param>
        /// <returns>An action result containing the generated JWT token if authentication is successful.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            // Authenticate the user using the provided credentials.
            var user = await _userService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (user == null)
                return Unauthorized();

            // Generate JWT token.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                    // Add other claims if needed
                }),
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpireHours),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Return the generated token.
            return Ok(new { Token = tokenString });
        }
    }
}
