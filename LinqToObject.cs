using PerformanceRecord.Classes;
using System;
using System.Linq;

namespace PerformanceRecord
{
    public class LinqToObject
    {

        //1 - Виводимо список студентів
        public void GetListStudents(Data d)
        {
            var result = from s in d.Students
                         select s;
            foreach (var student in result)
            {
                Console.WriteLine(student.ToString());
            }
        }

        //2 - Вивести студентів з непарним номером у списку
        public void GetStudentsWithOddId(Data d)
        {
            var result = d.Students.Where(s => s.StudentId % 2 != 0);
            foreach (var student in result)
            {
                Console.WriteLine(student.ToString());
            }
        }

        //3 - Згрупувати дисципліни за формами контролю
        public void GroupeDisciplineByFormOfControle(Data d)
        {
            var result = d.Disciplines.GroupBy(ds => ds.ConcreteFormOfControl);
            foreach (var groupe in result)
            {
                Console.WriteLine($"Form of controle {groupe.Key}\n");
                foreach (var discipline in groupe)
                {
                    Console.WriteLine(discipline.DisciplineName);
                }
            }

        }

        //4 - Дисципліни на курсі
        public void DisciplineOnCourse(Data d)
        {
            var result = d.Courses.Join(d.Disciplines,
                                        c => c.DisciplinId,
                                        ds => ds.DisciplineId,
                                        (c, ds) => new
                                        {
                                            courseNumber = c.NumberOfCourse,
                                            semestr = c.Semester,
                                            disciplineName = ds.DisciplineName,
                                        });
            foreach (var row in result)
            {
                Console.WriteLine($"{row.disciplineName} ({row.courseNumber} c, {row.semestr} semestr)");
            }
        }

        //5 - студенти з іменем що починається на літру D
        public void StudentsPIBStartWith(Data d, string fistLetter)
        {
            var result = d.Students.Where(s => s.PIB.StartsWith(fistLetter));
            foreach (var student in result)
            {
                Console.WriteLine(student.ToString());
            }
        }

        //6 - результати всіх студентів що вивчають дисципліну
        public void StudentResult(Data d)
        {
            var result = from dr in d.DisciplineResults
                         join s in d.Students on dr.StudentId equals s.StudentId
                         join ds in d.Disciplines on dr.DisciplineId equals ds.DisciplineId
                         group new { dr, s, ds } by ds.DisciplineName into g
                         select new
                         {
                             DisciplineName = g.Key,
                             StudentsResults = from x in g
                                               select new
                                               {
                                                   pib = x.s.PIB,
                                                   mark = x.dr.Mark
                                               }
                         };
            foreach (var item in result)
            {
                Console.WriteLine($"\n{item.DisciplineName}");

                foreach (var row in item.StudentsResults)
                {
                    Console.WriteLine($"      {row.pib} ({row.mark})");
                }
            }

        }
        //7 - студенти у яких оцінк вища або рівна 95
        public void StudentsWithMarkA(Data d)
        {
            var result = d.DisciplineResults.Where(dr => dr.Mark >= 95)
                                            .Join(d.Students,
                                                  dr => dr.StudentId,
                                                  s => s.StudentId,
                                                  (dr, s) => new
                                                  {
                                                      pib = s.PIB,
                                                      mark = dr.Mark
                                                  });
            foreach (var item in result)
            {
                Console.WriteLine($"{item.pib} ({item.mark})");
            }
        }

        //8 - студенти що отримали максимальну оцінку
        public void BestStudent(Data d)
        {
            var maxMark = d.DisciplineResults.Max(dr => dr.Mark);
            var result = from dr in d.DisciplineResults
                         where dr.Mark == maxMark
                         join s in d.Students on dr.StudentId equals s.StudentId
                         select new
                         {
                             pib = s.PIB,
                             mark = dr.Mark
                         };
            foreach (var item in result)
            {
                Console.WriteLine($"{item.pib} ({item.mark})");
            }
        }

        //9 - найвища оцінка яку було сароблено на дисципліні
        public void HighestMarkOnDiscipline(Data d)
        {
            var result = d.Disciplines.GroupJoin(d.DisciplineResults,
                                                 ds => ds.DisciplineId,
                                                 dr => dr.DisciplineId,
                                                 (ds, drGroup) => new
                                                 {
                                                     disciplineName = ds.DisciplineName,
                                                     mark = drGroup.Max(dr => dr.Mark)
                                                 });
            foreach (var item in result)
            {
                Console.WriteLine($"{item.disciplineName} -- (max student mark : {item.mark})");
            }
        }

        //10 - всі оцінки студента
        public void AllStudentsMark(Data d)
        {
            var result = from dr in d.DisciplineResults
                         join s in d.Students on dr.StudentId equals s.StudentId
                         join ds in d.Disciplines on dr.DisciplineId equals ds.DisciplineId
                         group new { dr, s, ds } by s.PIB into g
                         select new
                         {
                             PIB = g.Key,
                             StudentResults = from x in g
                                              select new
                                              {
                                                  disciplineName = x.ds.DisciplineName,
                                                  mark = x.dr.Mark
                                              }
                         };
            foreach (var item in result)
            {
                Console.WriteLine($"\n{item.PIB}");

                foreach (var row in item.StudentResults)
                {
                    Console.WriteLine($"      {row.disciplineName} ({row.mark})");
                }
            }
        }

        ////11 - максимальна оцінка конкретного студента
        public void StudentMaxMark(Data d)
        {
            //    var result = d.Students.GroupJoin(d.DisciplineResults,
            //                                      s => s.StudentId,
            //                                      dr => dr.StudentId,
            //                                      (s, drGroup) => new
            //                                      {
            //                                          pib = s.PIB,
            //                                          StudentResults = drGroup.Join(d.Disciplines,
            //                                                                      dr => dr.DisciplineId,
            //                                                                      ds => ds.DisciplineId,
            //                                                                      (drItem, ds) => new
            //                                                                      {
            //                                                                          disciplineName = ds.DisciplineName,
            //                                                                          mark = drGroup.Max(dr => drItem.Mark)
            //                                                                      }
            //                                                                      )
            //                                      }
            //                                      );
            //    foreach (var row in result)
            //    {
            //        Console.WriteLine($"{row.pib}");
            //        foreach (var item in row.StudentResults)
            //        {
            //            Console.WriteLine($"      {item.disciplineName} ({item.mark})");
            //        }
            //    }
          
        }
    

    //12 - обєднати перші три студента з рештою списку пропустивши першимих 5
    public void StudentsConcat(Data d)
        {
            var result = d.Students.Take(3).Concat(d.Students.Skip(5));
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
        }
        //13 - середня оцінка що отримали студенти за дисципліну
        public void AverageMarkOnDiscipline(Data d)
        {
            var result = d.Disciplines.GroupJoin(d.DisciplineResults,
                s => s.DisciplineId,
                dr => dr.StudentId,
                (s, drGroup) => new
                {
                    disciplineName = s.DisciplineName,
                    averageMark = drGroup.Average(dr => dr.Mark)
                });
            foreach (var row in result) 
            {
                Console.WriteLine($"{row.disciplineName}:\n   Average mark:{row.averageMark}");
            };
        }

        //14 - кількість дисциплін щовикладаються впродовж курсу
        public void NumberOfDisciplineOnCours(Data d)
        {
            var result = from c in d.Courses
                         join ds in d.Courses on c.DisciplinId equals ds.DisciplinId
                         group  ds by c.NumberOfCourse into g
                         select new
                         {
                             courseNumber = g.Key,
                             amountOfDisciplines = g.Count()
                         };

            foreach (var item in result)
            {
                Console.WriteLine($"\n{item.courseNumber} (Amount of Discipline {item.amountOfDisciplines})");
            }
          
        }

        //15 - середня оцінка студента
        public void AverageStudentMark(Data d)
        {
            var result = from s in d.Students
                         join dr in d.DisciplineResults on s.StudentId equals dr.StudentId
                         group dr by s.PIB into g
                         select new
                         {
                             pib = g.Key,
                             averageMark = g.Average(dr => dr.Mark)
                         };
            foreach (var row in result)
            {
                Console.WriteLine($"{row.pib}:\n   Average mark:{row.averageMark}");
            };
        }

        //16 - вибрати дисципліни в яких лише один кредитний модуль
        public void CreditModulOnDiscipline(Data d, int n) 
        {
            var result = from ds in d.Disciplines
                          where ds.NumberOfCreditModul == n.ToString()
                          select ds;
            foreach (var row in result)
            {
                Console.WriteLine(row.ToString());
            }
        }
        //17 - вивести дисципліни що починаються з літери M і обєднати їх з тими що починаються з літери J 
        public void ConcatDisciplinesStartWith(Data d, string letter1, string letter2)
        {
            var result1 = d.Disciplines.Where(ds => ds.DisciplineName.ToString().StartsWith(letter1));
            var result2 = d.Disciplines.Where(ds => ds.DisciplineName.ToString().StartsWith(letter2));
            var result = result1.Concat(result2).ToList();
            foreach (var row in result)
            {
                Console.WriteLine(row.ToString());
            }
        }

        //18 - впорядкувати дисципліни за алфавітом
        public void OrderByDisciplines (Data d)
        {
            var result = d.Disciplines.OrderBy(ds => ds.DisciplineName.ToString()).ToList();
            foreach (var row in result)
            {
                Console.WriteLine(row.ToString());
            }
        }
        //19 - вивести курс на який ще не додали дисципліни
        public void StudentWithoutDiscipline(Data d)
        {
            var result = from s in d.Students
                         join dr in d.DisciplineResults on s.StudentId equals dr.StudentId into sGroup
                         from dr in sGroup.DefaultIfEmpty()
                         select new
                         {
                             pib = s.PIB,
                             mark = dr?.Mark
                         };
            foreach (var row in result)
            {
                Console.WriteLine($"{row.pib} ({row.mark})");
            }
        }

        //20 - відсортувати оцінки студентів по кожній дисципліни від найбільшої до найменшої
        //public void OrderByMark(Data d)
        //{
          
        //    });
        //}

    }
}

   

