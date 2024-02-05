using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_31_01
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirh { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
