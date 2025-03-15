using Finanzauto.Application.Commons.Bases.Response;
using Finanzauto.Application.Dtos.Student.Request;
using Finanzauto.Application.Dtos.Student.Response;

namespace Finanzauto.Application.Interfaces
{
    public interface IStudentApplication
    {
        Task<BaseResponse<PagedResponse<StudentResponseDto>>> ListStudents();
        Task<BaseResponse<IEnumerable<StudentSelectResponseDto>>> ListSelectStudents();
        Task<BaseResponse<StudentResponseDto>> GetStudentById(int id);
        Task<BaseResponse<StudentResponseDto>> GetStudentByDocumentNumber(int documentNumber);
        Task<BaseResponse<bool>> CreateStudent(StudentRequestDto request);
        Task<BaseResponse<bool>> UpdateStudent(StudentRequestDto request, int id);
        Task<BaseResponse<bool>> DeleteStudent(int id);
    }
}
