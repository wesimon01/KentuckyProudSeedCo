using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KentuckyProudSeedCo.Service
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AuthenticationController(IConfiguration config, 
                                        SignInManager<IdentityUser> signInManager, 
                                        UserManager<IdentityUser> userManager)
        {
            this.config = config;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public class AuthenticationRequestBody 
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        public class KyProudUser 
        {
            public string Id { get; set; } = null!;
            public string UserName { get; set; } = null!;
        }

        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Authenticate(AuthenticationRequestBody authRequestBody) 
        { 
            if (authRequestBody == null) return BadRequest();

            var user = await ValidateUserCredentials(authRequestBody.UserName, authRequestBody.Password);
            
            if (user == null) return Unauthorized();

            var tokenToReturn = GenerateToken(user);

            return Ok(tokenToReturn);
        }

        private string GenerateToken(KyProudUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new();
            claims.Add(new(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new(JwtRegisteredClaimNames.UniqueName, user.UserName));

            var jwtSecurityToken = new JwtSecurityToken(config["Authentication:Issuer"],
                                                        config["Authentication:Audience"],
                                                        claims,
                                                        DateTime.UtcNow,
                                                        DateTime.UtcNow.AddHours(1),
                                                        signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private async Task<KyProudUser?> ValidateUserCredentials(string? userName, string? password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)) {
                return null;
            }
            
            var result = await signInManager.PasswordSignInAsync(userName, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(userName);
                return new KyProudUser { Id = user.Id, UserName = user.UserName };
            }
            else return null; 
        }
    }
}
