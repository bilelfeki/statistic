using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using statistique2.DBConnextion;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication2.DTO;
using statistique.Models;
using Microsoft.AspNetCore.Cors;

namespace statistique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // POST: api/Auth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("login/famous")]
        public ActionResult<Famous> PostFamous(Famous famous)
        {

            using (var context = new AppDbContext())
            {
                if (famous is null || famous.Followers is not null)
                {
                    return BadRequest("Invalid client request");
                }

                if (context.Famous.Where(fam =>
                fam.Name == famous.Name && fam.Password == famous.Password)
                    .Any())

                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5001",
                        audience: "https://localhost:5001",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new AuthenticatedResponse { Token = tokenString });
                }
                return Unauthorized();
            }
        }
        [HttpPost("login/follower")]
        public ActionResult<Famous> PostFollower(Follower follower)
        {

            using (var context = new AppDbContext())
            {
                if (follower is null || follower.YourFamous is not null)
                {
                    return BadRequest("Invalid client request");
                }

                if (context.Followers.Where(fol =>
                fol.Name == follower.Name && fol.Password == follower.Password)
                    .Any())

                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5001",
                        audience: "https://localhost:5001",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new AuthenticatedResponse { Token = tokenString });
                }
                return Unauthorized();
            }
        }
    }
}
