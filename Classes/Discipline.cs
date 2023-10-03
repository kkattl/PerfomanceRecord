namespace PerformanceRecord.Classes
{
    public class Discipline
    {
        public int DisciplineId { get; private set; }
        public DisciplineNames DisciplineName { get; private set; }
        public FormOfControl ConcreteFormOfControl { get; private set; }
        public string NumberOfCreditModul { get; private set; }
        
        public Discipline(int disciplineId, DisciplineNames name, FormOfControl formOfControl, string numberOfCreditModul)
        {
            this.DisciplineId = disciplineId;
            this.DisciplineName = name;
            this.ConcreteFormOfControl = formOfControl;
            this.NumberOfCreditModul = numberOfCreditModul;
        }

        public enum DisciplineNames
        {
            Math, 
            Physics,
            Programming,
            DB,
            Philosophy,
            TheoryOfAlgorithms,
            JS,
            C,
            Java
        }
        public enum FormOfControl
        {
            Test,
            Exam,
        }
       
        public override string ToString()
        {
            return $"DisciplineName of discipline {DisciplineName}\n Type: {ConcreteFormOfControl}\n Number of credit modul {NumberOfCreditModul}";
        }

    }
}
