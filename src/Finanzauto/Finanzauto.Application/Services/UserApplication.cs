using AutoMapper;
using Finanzauto.Application.Commons.Bases.Response;
using Finanzauto.Application.Dtos.User.Request;
using Finanzauto.Application.Interfaces;
using Finanzauto.Application.Validators;
using Finanzauto.Utilities.Static;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Finanzauto.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly RegisterUserValidator _registerUserValidator;

        public UserApplication(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IMapper mapper,
            RegisterUserValidator registerUserValidator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _registerUserValidator = registerUserValidator;
        }


        public async Task<BaseResponse<bool>> RegisterUserAsync(RegisterUserRequestDto request)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var validationResult = await _registerUserValidator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_VALIDATE;
                    response.Errors = validationResult.Errors;
                    return response;
                }

                var userAlready = await _userManager.FindByEmailAsync(request.Email!);

                if (userAlready != null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_USER_EXIST;
                    return response;
                }

                var user = _mapper.Map<IdentityUser>(request);

                var result = await _userManager.CreateAsync(user, request.Password!);

                if (result.Succeeded)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_USER_SUSSCESS_REGISTER;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                    response.Message = result.Errors.Select(e => e.Description).ToString();
                }
            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> LogoutAsync()
        {
            var response = new BaseResponse<bool>();

            try
            {
                await _signInManager.SignOutAsync();

                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_USER_SUSSCESS_LOGOUT;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
