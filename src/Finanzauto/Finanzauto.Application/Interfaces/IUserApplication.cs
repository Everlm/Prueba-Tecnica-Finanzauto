using Finanzauto.Application.Commons.Bases.Response;
using Finanzauto.Application.Dtos.User.Request;

namespace Finanzauto.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<bool>> RegisterUserAsync(RegisterUserRequestDto request);
        Task<BaseResponse<bool>> LogoutAsync();
    }
}
