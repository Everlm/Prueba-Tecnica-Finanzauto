using AutoMapper;
using Finanzauto.Application.Commons.Bases.Response;
using Finanzauto.Application.Dtos.Student.Request;
using Finanzauto.Application.Dtos.Student.Response;
using Finanzauto.Application.Interfaces;
using Finanzauto.Application.Validators;
using Finanzauto.Domain.Entities;
using Finanzauto.Infrastructure.Persistences.Interfaces;
using Finanzauto.Utilities.Static;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Application.Services
{
    public class StudentApplication : IStudentApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly StudentValidator _validateRules;

        public StudentApplication(IUnitOfWork unitOfWork, IMapper mapper, StudentValidator validateRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validateRules = validateRules;
        }

        public async Task<BaseResponse<PagedResponse<StudentResponseDto>>> ListStudents()
        {
            var response = new BaseResponse<PagedResponse<StudentResponseDto>>();

            try
            {

                var studentsQueryable = _unitOfWork.Student.GetAllQueryable();

                var totalRecords = await studentsQueryable.CountAsync();

                const int pageSize = 10;
                const int pageNumber = 1;

                var pagedStudents = await studentsQueryable
                    .OrderBy(s => s.FirstName)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var studentsDto = _mapper.Map<IEnumerable<StudentResponseDto>>(pagedStudents);

                var pagedResponse = new PagedResponse<StudentResponseDto>
                {
                    Data = studentsDto,
                    Total = totalRecords,
                    Page = pageNumber,
                    Limit = pageSize
                };

                response.IsSuccess = true;
                response.Data = pagedResponse;
                response.TotalRecords = totalRecords;
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<StudentSelectResponseDto>>> ListSelectStudents()
        {
            var response = new BaseResponse<IEnumerable<StudentSelectResponseDto>>();

            try
            {
                var students = await _unitOfWork.Student.GetAllAsync();

                if (students is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<StudentSelectResponseDto>>(students);
                    response.TotalRecords = students.Count();
                    response.Message = ReplyMessage.MESSAGE_QUERY;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }

        public async Task<BaseResponse<StudentResponseDto>> GetStudentById(int id)
        {
            var response = new BaseResponse<StudentResponseDto>();

            try
            {
                var student = await _unitOfWork.Student.GetByIdAsync(id);

                if (student is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<StudentResponseDto>(student);
                    response.TotalRecords = 1;
                    response.Message = ReplyMessage.MESSAGE_QUERY;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }

        public async Task<BaseResponse<StudentResponseDto>> GetStudentByDocumentNumber(int documentNumber)
        {
            var response = new BaseResponse<StudentResponseDto>();

            try
            {
                var studentQueryable = _unitOfWork.Student.GetAllQueryable();

                var student = await studentQueryable.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber);

                if (student is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<StudentResponseDto>(student);
                    response.TotalRecords = 1;
                    response.Message = ReplyMessage.MESSAGE_QUERY;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> CreateStudent(StudentRequestDto request)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var validationResult = await _validateRules.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_VALIDATE;
                    response.Errors = validationResult.Errors;
                    return response;
                }

                var category = _mapper.Map<Student>(request);
                response.Data = await _unitOfWork.Student.CreateAsync(category);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message += ReplyMessage.MESSAGE_SAVE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> UpdateStudent(StudentRequestDto request, int id)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var studentUpdate = await GetStudentById(id);

                if (studentUpdate.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                var student = _mapper.Map<Student>(request);
                student.Id = id;
                response.Data = await _unitOfWork.Student.UpdateAsync(student);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_UPDATE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;

            }

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteStudent(int id)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var student = await GetStudentById(id);

                if (student.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }

                response.Data = await _unitOfWork.Student.DeleteAsync(id);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_DELETE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            }

            return response;
        }


    }
}
