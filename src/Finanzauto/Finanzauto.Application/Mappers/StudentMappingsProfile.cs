using AutoMapper;
using Finanzauto.Application.Dtos.Student.Request;
using Finanzauto.Application.Dtos.Student.Response;
using Finanzauto.Domain.Entities;
using Finanzauto.Utilities.Static;

namespace Finanzauto.Application.Mappers
{
    public class StudentMappingsProfile : Profile
    {
        public StudentMappingsProfile()
        {
            CreateMap<Student, StudentResponseDto>()                
                 .ForMember(x => x.StudentState, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Active" : "Inactive"))
                 .ReverseMap();

            CreateMap<StudentRequestDto, Student>();

            CreateMap<Student, StudentSelectResponseDto>()
                 .ReverseMap();
        }
    }
}
