namespace PerformanceRecord.Classes
{
    public class Course
    {
        public NumberOfCourses NumberOfCourse { get; private set; }
        public int DisciplinId { get; private set; }
        public Semesters Semester { get; private set; }
        
        public enum NumberOfCourses
        {
            First = 1,
            Second = 2,
            Third = 3,
            Forth = 4,
        }
        public enum Semesters
        {
            First = 1,
            Second = 2,
        }

        public Course(NumberOfCourses numberOfCourse, Semesters semester,int disciplinId)
        {
            this.NumberOfCourse = numberOfCourse;
            this.Semester = semester;
            this.DisciplinId = disciplinId;
        }

    }
}
