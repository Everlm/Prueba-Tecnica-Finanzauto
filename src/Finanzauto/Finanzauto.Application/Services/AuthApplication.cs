using AutoMapper;
using Finanzauto.Application.Commons.Bases.Response;
using Finanzauto.Application.Dtos.Auth.Request;
using Finanzauto.Application.Dtos.Auth.Response;
using Finanzauto.Application.Interfaces;
using Finanzauto.Application.Validators;
using Finanzauto.Utilities.Static;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Finanzauto.Application.Services
{
    public class AuthApplication : IAuthApplication
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly LoginValidator _loginValidator;
        private readonly IConfiguration _config;


        public AuthApplication(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IMapper mapper,
            LoginValidator loginValidator,
            IConfiguration config
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _loginValidator = loginValidator;
            _config = config;
        }

        public async Task<BaseResponse<LoginResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var response = new BaseResponse<LoginResponseDto>();

            try
            {
                var validationResult = await _loginValidator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_VALIDATE;
                    response.Errors = validationResult.Errors;
                    return response;
                }

                var user = await _userManager.FindByEmailAsync(request.Email!);

                if (user is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_USER_NOTFOUND;
                    return response;
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_USER_SUSSCESS_LOGIN;
                    var loginResponse = _mapper.Map<LoginResponseDto>(user);
                    loginResponse.Token = GenerateToken(user);
                    response.Data = loginResponse;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_USER_PASSWORD_VERIFY;

                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        private string GenerateToken(IdentityUser user)
        {

            var jwtSettings = _config.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(jwtSettings["Expiret"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
