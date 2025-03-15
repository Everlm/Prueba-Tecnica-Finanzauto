using Finanzauto.Application.Dtos.Student.Request;
using Finanzauto.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finanzauto.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentApplication _studentApplication;
        public StudentController(IStudentApplication studentApplication)
        {
            _studentApplication = studentApplication;
        }

        [HttpGet("students/list-paginated")]
        public async Task<IActionResult> GetStudentsPaginated()
        {
            var response = await _studentApplication.ListStudents();
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectStudents()
        {
            var response = await _studentApplication.ListSelectStudents();
            return Ok(response);
        }

        [HttpGet("by-id/{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var response = await _studentApplication.GetStudentById(id);
            return Ok(response);
        }

        [HttpGet("by-document/{documentNumber:int}")]
        public async Task<IActionResult> GetStudentByDocumentNumber(int documentNumber)
        {
            var response = await _studentApplication.GetStudentByDocumentNumber(documentNumber);
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequestDto request)
        {
            var response = await _studentApplication.CreateStudent(request);
            return Ok(response);
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentRequestDto request)
        {
            var response = await _studentApplication.UpdateStudent(request, id);
            return Ok(response);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var response = await _studentApplication.DeleteStudent(id);
            return Ok(response);
        }

    }
}
