using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ResumeBuilderCapstone.Middleware;
using ResumeBuilderCapstone.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ResumeBuilderCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ResumeDbContext _context;
        private readonly IConfiguration _config;

        public UsersController(ResumeDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("/Login/{Email}/{Password}")]
        public async Task<ActionResult<string>> Login(string Email, string Password)
        {
            Users userFound = await _context.Users.Where(x => x.Email == Email).FirstOrDefaultAsync();

            if (userFound == null)
            {
                return Unauthorized("Invalid credentials");
            }

            string? encry = userFound.Password;
            string pwd = DecryptionHelper.Decrypt(encry);

            if (!pwd.Equals(Password))
            {
                return Unauthorized("Invalid credentials");
            }

            // Generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userFound.FullName),
                    new Claim(ClaimTypes.Email, userFound.Email),
                    new Claim("UserId", userFound.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return Ok(new { token = jwtToken });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<string>> PostUser(Users user)
        {
            string pwd = EncryptionHelper.Encrypt(user.Password);
            user.Password = pwd;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "Account Created Successfully...";
        }


        // GET: api/Users/ByEmail/{email}
        [HttpGet("ByEmail/{email}")]
        public async Task<ActionResult<Users>> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}