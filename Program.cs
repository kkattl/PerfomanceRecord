using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceRecord.Classes;

namespace PerformanceRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data d = new Data();
            LinqToObject linqToObject = new LinqToObject();
            //linqToObject.GetListStudents(d);
            //linqToObject.GetStudentsWithOddId(d);
            //linqToObject.GroupeDisciplineByFormOfControle(d);
            //linqToObject.DisciplineOnCourse(d);
            //linqToObject.StudentsPIBStartWith(d, "D");
            //linqToObject.StudentResult(d);
            //linqToObject.StudentsWithMarkA(d);
            //linqToObject.BestStudent(d);
            //linqToObject.HighestMarkOnDiscipline(d);
            //linqToObject.AllStudentsMark(d);
            linqToObject.StudentMaxMark(d);
            //linqToObject.StudentsConcat(d);?
            //linqToObject.AverageMarkOnDiscipline(d);
            //linqToObject.NumberOfDisciplineOnCours(d);
            //linqToObject.CreditModulOnDiscipline(d, 1);
            //linqToObject.ConcatDisciplinesStartWith(d, "M", "J");
            //linqToObject.OrderByDisciplines(d);
            //linqToObject.StudentWithoutDiscipline(d);
            Console.ReadKey();
        }
    }
}
