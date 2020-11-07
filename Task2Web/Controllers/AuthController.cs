using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Task2Web.Models;

namespace Task2Web.Controllers
{
    //route attribute
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly ApplicationContext userContext;

        public AuthController(ApplicationContext userContext)
        {
            this.userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }
        //Why ActionResult ????? One reason why is that the action result contains two important pieces of the result,for status code and body content
        // post request
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null)
                return BadRequest("Invalid client request");

            var user = userContext.LoginModels
       .FirstOrDefault(u => (u.UserName == loginModel.UserName) &&
                               (u.Password == loginModel.Password));

            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            else if (user != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                //passing secret key and security algorithm
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                //create claims by adding the username and the role claim to the Claim list.
                var claims = new List<Claim>
              {
                  new Claim(ClaimTypes.Name, user.UserName ),
                  new Claim(ClaimTypes.Role, "Manager")
              };

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:50271/",
                    audience: "http://localhost:50271/",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }

    }
}