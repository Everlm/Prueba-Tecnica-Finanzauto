namespace Finanzauto.Domain.Entities
{
    public class Student : BaseEntity
    {
        public int DocumentNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
