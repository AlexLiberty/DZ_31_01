using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_31_01
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LIBERTY; Database=DZ_31_01_1; Trusted_Connection=True; TrustServerCertificate=True; Integrated Security=True;");
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructors)
                .WithMany(i => i.Courses)
                .UsingEntity(j => j.ToTable("CourseInstructor"));

            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Alice", LastName = "Johnson", DateOfBirh = new DateTime(1998, 5, 15) },
                new Student { Id = 2, FirstName = "Alice1", LastName = "Johnson1", DateOfBirh = new DateTime(1999, 6, 16) },
                new Student { Id = 3, FirstName = "Alice2", LastName = "Johnson2", DateOfBirh = new DateTime(2000, 7, 17) },
                new Student { Id = 4, FirstName = "Alice3", LastName = "Johnson3", DateOfBirh = new DateTime(2001, 8, 18) },
                new Student { Id = 5, FirstName = "Alice4", LastName = "Johnson4", DateOfBirh = new DateTime(2002, 9, 19) },
                new Student { Id = 6, FirstName = "Alice5", LastName = "Johnson5", DateOfBirh = new DateTime(2003, 10, 20) },
                new Student { Id = 7, FirstName = "Alice6", LastName = "Johnson6", DateOfBirh = new DateTime(2004, 11, 21) },
                new Student { Id = 8, FirstName = "Alice7", LastName = "Johnson7", DateOfBirh = new DateTime(2005, 12, 22) }
                );
            modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Title = "Mathematics", Description = "Introduction to Mathematics"},
            new Course { Id = 2, Title = "History", Description = "World History" },
            new Course { Id = 3, Title = "Computer Science", Description = "Fundamentals of Computer Science" },
            new Course { Id = 4, Title = "English Literature", Description = "Literature and Composition" },
            new Course { Id = 5, Title = "Biology", Description = "Introduction to Biology" }
            );

            modelBuilder.Entity<Enrollment>().HasData(
     new Enrollment { Id = 1, StudentId = 1, CourseId=1, EnrollmentDate=DateTime.Now.AddMonths(-1) },
     new Enrollment { Id = 2, StudentId = 2, CourseId = 2, EnrollmentDate = DateTime.Now.AddMonths(-200) },
     new Enrollment { Id = 3, StudentId = 3, CourseId = 3, EnrollmentDate = DateTime.Now.AddMonths(-125) },
     new Enrollment { Id = 4, StudentId = 4, CourseId = 4, EnrollmentDate = DateTime.Now.AddMonths(-48) },
     new Enrollment { Id = 5, StudentId = 5, CourseId = 5, EnrollmentDate = DateTime.Now.AddMonths(-2) },
     new Enrollment { Id = 6, StudentId = 6, CourseId = 5, EnrollmentDate = DateTime.Now.AddMonths(-1) },
     new Enrollment { Id = 7, StudentId = 6, CourseId = 5, EnrollmentDate = DateTime.Now.AddMonths(-38) },
     new Enrollment { Id = 8, StudentId = 7, CourseId = 1, EnrollmentDate = DateTime.Now.AddMonths(-79) },
     new Enrollment { Id = 9, StudentId = 8, CourseId = 2, EnrollmentDate = DateTime.Now.AddMonths(-1) },
     new Enrollment { Id = 10, StudentId = 2, CourseId = 5, EnrollmentDate = DateTime.Now.AddMonths(-83) },
     new Enrollment { Id = 11, StudentId = 2, CourseId = 4, EnrollmentDate = DateTime.Now.AddMonths(-298) }
     );
            modelBuilder.Entity<Instructor>().HasData(
new Instructor { Id = 1, FirstName= "John", LastName="Doe"},
new Instructor { Id = 2, FirstName = "Jone", LastName = "Smith" },
new Instructor { Id = 3, FirstName = "Michael", LastName = "Johnson" }
);

        }
    }
}
