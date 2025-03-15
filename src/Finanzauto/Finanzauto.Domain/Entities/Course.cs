namespace Finanzauto.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
