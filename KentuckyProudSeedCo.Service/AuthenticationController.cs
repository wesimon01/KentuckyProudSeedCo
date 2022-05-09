using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KentuckyProudSeedCo.Service
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration config;

        public AuthenticationController(IConfiguration config)
        {
            this.config = config;
        }

        public class AuthenticationRequestBody 
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        public class KyProudUser 
        {
            public int Id { get; set; }
            public string? UserName { get; set; }
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authRequestBody) 
        { 
            var user = ValidateUserCredentials(authRequestBody.UserName, authRequestBody.Password);
            
            if (user == null) { return Unauthorized(); }

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));            

            var jwtSecurityToken = new JwtSecurityToken(config["Authentication:Issuer"], config["Authentication:Audience"],
                                                        claimsForToken, DateTime.UtcNow, 
                                                        DateTime.UtcNow.AddHours(1), signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private KyProudUser ValidateUserCredentials(string? userName, string? password)
        {
            return new KyProudUser { Id = 1, UserName = "evan.simon@kyproudseedco.com" };
        }
    }
}
