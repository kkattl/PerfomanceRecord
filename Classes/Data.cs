using System.Collections.Generic;

namespace PerformanceRecord.Classes
{
    public class Data
    {
        public List<Student> Students = new List<Student>()
        {
            new Student(1, "John Smith"),
            new Student(2, "Mary Johnson"),
            new Student(3, "David Williams"),
            new Student(4, "Linda Jones"),
            new Student(5, "Michael Brown"),
            new Student(6, "Sarah Davis"),
            new Student(7, "James Miller"),
            new Student(8, "Karen Wilson"),
            new Student(9, "Robert Moore"),
            new Student(10, "Jennifer Taylor"),
            new Student(11, "Marisa Vert"),
            new Student(12, "Martin Drew")
        };

        public List<Discipline> Disciplines = new List<Discipline>()
        {
            new Discipline(1, Discipline.DisciplineNames.Math, Discipline.FormOfControl.Test, "1"),
            new Discipline(2, Discipline.DisciplineNames.Physics, Discipline.FormOfControl.Exam, "1"),
            new Discipline(3, Discipline.DisciplineNames.Programming, Discipline.FormOfControl.Test, "2"),
            new Discipline(4, Discipline.DisciplineNames.DB, Discipline.FormOfControl.Exam, "2"),
            new Discipline(5, Discipline.DisciplineNames.Philosophy, Discipline.FormOfControl.Test, "1"),
            new Discipline(6, Discipline.DisciplineNames.TheoryOfAlgorithms, Discipline.FormOfControl.Exam, "2"),
            new Discipline(7, Discipline.DisciplineNames.JS, Discipline.FormOfControl.Test, "4"),
            new Discipline(8, Discipline.DisciplineNames.C, Discipline.FormOfControl.Exam, "4"),
            new Discipline(9, Discipline.DisciplineNames.Java, Discipline.FormOfControl.Test, "4"),
        };

        public List<Course> Courses = new List<Course>()
        {
            new Course(Course.NumberOfCourses.First, Course.Semesters.First, 1),
            new Course(Course.NumberOfCourses.First, Course.Semesters.Second, 2),
            new Course(Course.NumberOfCourses.First, Course.Semesters.First, 3),
            new Course(Course.NumberOfCourses.First, Course.Semesters.Second, 3),
            new Course(Course.NumberOfCourses.Second, Course.Semesters.First, 4),
            new Course(Course.NumberOfCourses.Second, Course.Semesters.Second, 4),
            new Course(Course.NumberOfCourses.Second, Course.Semesters.Second, 5),
            new Course(Course.NumberOfCourses.Third, Course.Semesters.First, 6),
            new Course(Course.NumberOfCourses.Third, Course.Semesters.Second, 6),
            new Course(Course.NumberOfCourses.Third, Course.Semesters.First, 7),
            new Course(Course.NumberOfCourses.Third, Course.Semesters.Second, 7),
            new Course(Course.NumberOfCourses.Third, Course.Semesters.First, 8),
            new Course(Course.NumberOfCourses.Third, Course.Semesters.Second, 8),
            new Course(Course.NumberOfCourses.Third, Course.Semesters.First, 9),
            new Course(Course.NumberOfCourses.Third, Course.Semesters.Second, 9),
        };

        public List<DisciplineResult> DisciplineResults = new List<DisciplineResult>()
        {
            new DisciplineResult(1, 1, 85), 
            new DisciplineResult(1, 2, 92), 
            new DisciplineResult(2, 1, 78), 
            new DisciplineResult(2, 2, 88), 
            new DisciplineResult(3, 3, 75), 
            new DisciplineResult(3, 4, 90), 
            new DisciplineResult(4, 1, 95), 
            new DisciplineResult(4, 2, 80), 
            new DisciplineResult(5, 3, 18), 
            new DisciplineResult(5, 4, 85), 
            new DisciplineResult(6, 5, 65), 
            new DisciplineResult(6, 6, 95), 
            new DisciplineResult(7, 7, 100), 
            new DisciplineResult(7, 8, 83), 
            new DisciplineResult(8, 7, 90), 
            new DisciplineResult(8, 8, 78), 
            new DisciplineResult(9, 7, 40), 
            new DisciplineResult(9, 8, 92), 
            new DisciplineResult(10, 9, 100) 

        };
    }
}
