using AutoMapper;
using Finanzauto.Application.Dtos.Auth.Response;
using Finanzauto.Application.Dtos.User.Request;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.Application.Mappers
{
    public class AuthMappingsProfile : Profile
    {
        public AuthMappingsProfile()
        {
            CreateMap<IdentityUser, RegisterUserRequestDto>()
               .ForMember(x => x.Email, x => x.MapFrom(y => y.UserName));

            CreateMap<RegisterUserRequestDto, IdentityUser>()
                .ForMember(x => x.UserName, x => x.MapFrom(y => y.Email));
            
            CreateMap<IdentityUser, LoginResponseDto>();
        }
    }
}
