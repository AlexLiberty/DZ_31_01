using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_31_01
{
    public class Course
    {
        public int Id {  get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public ICollection<Enrollment> Enrollments { get; set;}
        public ICollection<Instructor> Instructors { get; set;}
    }
}
