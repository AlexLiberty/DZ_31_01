using DZ_31_01;
using System.Net.Cache;

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    EnsurePopulate(db);
}

void EnsurePopulate(ApplicationContext db)
{
    var instructors=db.Instructors.ToList();
    instructors[0].Courses.Add(db.Courses.FirstOrDefault(e=>e.Title.Equals("Mathematics")));
    instructors[0].Courses.Add(db.Courses.FirstOrDefault(e => e.Title.Equals("Computer Science")));
    instructors[1].Courses.Add(db.Courses.FirstOrDefault(e => e.Title.Equals("History")));
    instructors[2].Courses.Add(db.Courses.FirstOrDefault(e => e.Title.Equals("Biology")));
    instructors[2].Courses.Add(db.Courses.FirstOrDefault(e => e.Title.Equals("English Literature")));
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    //var query1 = db.Enrollments.Where(e=>e.CourseId == 1).Select(e=>e.Student).ToList();
    //var query2 = db.Courses.Where(e=>e.Instructors.Any(e=>e.Id==1)).ToList();
    //var query3 = db.Courses.Where(e=>e.Instructors.Any(e=>e.Id==1)).Select(c=>new
    //{
    //    Course = c,
    //    Students = c.Enrollments.Select(e => e.Student).Select(e => e.FirstName)
    //}).ToList();
    //var query4 = db.Courses.Where(e=>e.Enrollments.Count()>2).ToList();
    //var query5 = db.Students.Where(e=>DateTime.Now.Year-e.DateOfBirh.Year>25);
    //var query6 = db.Students.Average(e=>DateTime.Now.Year-e.DateOfBirh.Year);
    //var query7 = db.Students.OrderBy(e=>e.DateOfBirh).FirstOrDefault();
    //var query8 = db.Enrollments.Count(e=>e.StudentId==1);
    //var query9 = db.Students.Select(e=>e.FirstName).ToList();
    //var query10 = db.Students.GroupBy(e=>DateTime.Now.Year-e.DateOfBirh.Year).Select(e=>new
    //{
    //    Age=e.Key,
    //    Count=e.Count()
    //}).ToList();
    var query11 = db.Students.GroupBy(e => DateTime.Now.Year - e.DateOfBirh.Year)
                        .Select(c => new
                        {
                            Age = c.Key,
                            Students = c.ToList()
                        })
                        .ToList();
    var query12 = db.Students.OrderBy(e => e.LastName).ToList();
    var query13 = db.Students.Select(e => new
    {
        Student = e,
        Enrollments = e.Enrollments.ToList()
    })
               .ToList();

    var query14 = db.Students.Where(s => !s.Enrollments.Any(e => e.CourseId == 1)).ToList();

    var query15 = db.Students.Where(s => s.Enrollments.Any(e => e.CourseId == 1) && s.Enrollments.Any(e => e.CourseId == 2)).ToList();

    var query16 = db.Courses.Select(c => new
    {
        Course = c,
        StudentCount = c.Enrollments.Count
    })
               .ToList();
}