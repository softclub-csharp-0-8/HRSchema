using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Domain.Dtos.AuthenticationAuthorizationDto;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens; 

namespace Infrastructure.Services.Account;

public class AccountService:IAccountService 
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AccountService(IConfiguration configuration, UserManager<IdentityUser> userManager, DataContext context, IMapper mapper )
    {
        _configuration = configuration;
        _userManager = userManager;
        _context = context;
        _mapper = mapper; 
    }

    public async Task<Response<IdentityResult>> Register(RegisterDto model)
    {
        var user = new IdentityUser() 
        {
            UserName = model.UserName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        return new Response<IdentityResult>(result);

    }

    public async Task<Response<TokenDto>> Login(LoginDto model)
    {
        var existing = await _userManager.FindByNameAsync(model.UserName);
        if (existing == null)
        {
            return new Response<TokenDto>(HttpStatusCode.BadRequest,
                new List<string>() { "Incorrect password or UserName" }); 
        }

        var check = await _userManager.CheckPasswordAsync(existing, model.Password);
         
        if (check == true)
        {
            return new Response<TokenDto>(await GenerateJWTToken(existing));
            
        }
        else
        {
            return new Response<TokenDto>(HttpStatusCode.BadRequest,
                new List<string>()); 
        }
    }

    private async Task<TokenDto> GenerateJWTToken(IdentityUser user)
    {
        return await Task.Run(() =>
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                Issuer = _configuration["jwt:Issuer"],
                Audience = _configuration["jwt:Audience"],
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            var tokenString = tokenHandler.WriteToken(token);
            return new TokenDto(tokenString);
        });

    }

}