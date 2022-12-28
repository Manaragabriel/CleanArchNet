using CleanArch_Application.UseCases.Auth.Login;
using CleanArch_Application.UseCases.User.Create;
using CleanArch_Infrastructure.Database.User.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchNet.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController 
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IConfiguration _configuration;


        public UserController(UserManager<UserModel> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var userModel = new UserModel()
            {
                UserName = createUserDTO.Name,
                Name = createUserDTO.Name,
                Password = createUserDTO.Password,
                Email = createUserDTO.Email,
                EmailConfirmed = true,
                IsActive = true,

            };
            var result = await _userManager.CreateAsync(userModel, createUserDTO.Password);

            return new CreatedResult("",result.Errors);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Email);
            var authClaims = new List<Claim>
                {
                    new Claim("userName", user.UserName),
                };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                claims: authClaims
           );


            return new CreatedResult("", new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
