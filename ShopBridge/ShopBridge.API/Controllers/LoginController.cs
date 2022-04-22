using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopBridge.API.Configuration;
using ShopBridge.Contracts.Request;
using ShopBridge.Services.Core.Interfaces;
using ShopBridge.Services.Core.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.API.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IOptions<JwtConfig> _jwtOptions;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginController(IOptions<JwtConfig> jwtOptions, IUserService userService, IMapper mapper)
        {
            _jwtOptions = jwtOptions ?? throw new ArgumentNullException(nameof(jwtOptions));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            UserLogin login = _mapper.Map<UserLogin>(userLoginDto);
            User user = await _userService.Login(login);

            if (user is null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(_jwtOptions.Value.Issuer, _jwtOptions.Value.Audience, claims, null, DateTime.Now.AddDays(1), credentials);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
