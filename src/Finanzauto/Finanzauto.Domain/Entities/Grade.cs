namespace Finanzauto.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Score { get; set; }
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
