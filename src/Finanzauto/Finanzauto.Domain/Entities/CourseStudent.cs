using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.Domain.Entities
{
    public class CourseStudent
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}
