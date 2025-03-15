namespace Finanzauto.Application.Dtos.Student.Response
{
    public class StudentResponseDto
    {
        public int Id { get; set; }
        public int DocumentNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int State { get; set; }
        public string? StudentState { get; set; }
    }
}
