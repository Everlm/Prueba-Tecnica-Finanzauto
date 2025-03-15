namespace Finanzauto.Application.Dtos.Student.Request
{
    public class StudentRequestDto
    {
        public int DocumentNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int State { get; set; }
    }
}
