namespace PerformanceRecord.Classes
{
    public class Student
    {
        public int StudentId { get; private set; }
        public string PIB { get; private set; }
       
        public Student(int studentId, string pib)
        {
            this.StudentId = studentId;
            this.PIB = pib;
        }
        public override string ToString() 
        {
            return $"{StudentId} - {PIB}";
        }
        
    }
}
