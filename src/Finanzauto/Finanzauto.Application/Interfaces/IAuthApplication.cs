using Finanzauto.Application.Commons.Bases.Response;
using Finanzauto.Application.Dtos.Auth.Request;
using Finanzauto.Application.Dtos.Auth.Response;

namespace Finanzauto.Application.Interfaces
{
    public interface IAuthApplication
    {
        Task<BaseResponse<LoginResponseDto>> LoginAsync(LoginRequestDto request);
    }
}
