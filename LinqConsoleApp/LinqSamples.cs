using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }


        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public void Przyklad1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job
                      };

            foreach (var r in res)
            {
                Console.WriteLine(r);                
            }
            //2. Lambda and Extension methods
            var ress = Emps.Where(x => x.Job == "Backend programmer").Select(x => new
            {
                Nazwisko = x.Ename,
                Zawod = x.Job
            });
            
            foreach (var rs in ress)
            {
                Console.WriteLine(rs);
            }
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Przyklad2()
        {
            var ex = from emp in Emps
                where emp.Job == "Frontend programmer" && emp.Salary > 1000 orderby emp.Ename descending
                select new
                {
                    Nazwisko = emp.Ename,
                    Zawod = emp.Job
                };

            foreach (var e in ex)
            {
                Console.WriteLine(e);
            }
            
            //2. Lambda and Extension methods
            var exx = Emps.Where(x => x.Job == "Frontend programmer" && x.Salary > 1000).OrderByDescending(x => x.Ename).Select(x => new {
                Nazwisko = x.Ename,
                Zawod = x.Job
            });

            foreach (var e in exx)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Przyklad3()
        {
            var ex = Emps.Max(emp => emp.Salary);

            var exx = (from emp in Emps select emp.Salary).Max();
            Console.WriteLine(ex);
            Console.WriteLine(exx);
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Przyklad4()
        {
            var max = Emps.Max(emp => emp.Salary);
            var ex = Emps.Where(x=>x.Salary == max).Select(x => new {
                Nazwisko = x.Ename,
                Zawod = x.Job,
                Płaca = x.Salary
            });

            var ex2 = Emps.Where(emp => emp.Salary == Emps.Max(emp1 => emp1.Salary));
            foreach (var e in ex)
            {
                Console.WriteLine(e);
            }

            foreach (var e in ex2)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public void Przyklad5()
        {
            var ex = from emp in Emps select new {
                Nazwisko = emp.Ename,
                Praca = emp.Job
            };

            foreach (var e in ex)
            {
                Console.WriteLine(e);
            }
            
            var exx = Emps.Select(x => new {
                Nazwisko = x.Ename,
                Praca = x.Job
            });

            foreach (var e in exx)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public void Przyklad6()
        {
            var ex = from emp in Emps
                join dept in Depts on emp.Deptno equals dept.Deptno
                select new
                {
                    emp.Ename,
                    emp.Job,
                    dept.Dname
                };

            foreach (var e in ex)
            {
                Console.WriteLine(e);
            }
            
            var exx = Emps.Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new
            {
                emp.Ename,
                emp.Job,
                dept.Dname
            });

            foreach (var e in exx)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public void Przyklad7()
        {
            var ex = from emp in Emps
                group emp by emp.Job into p
                select new
                {
                    Praca = p.Key,
                    LiczbaPracownikow = p.Count()
                };

            var exx = Emps.GroupBy(emp => emp.Job).Select(emp => new
            {
                Praca = emp.Key,
                LiczbaPracownikow = emp.Count()
            });
            
            foreach (var e in exx)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public void Przyklad8()
        {
            var ex = Emps.Any(x => x.Job == "Backend programmer").ToString();
            
            var exx = (from x in Emps
                where x.Job == "Backend programmer"
                select x).Any();

            Console.WriteLine(ex);

            Console.WriteLine(exx);
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Przyklad9()
        {
            var ex = Emps.Where(emp => emp.Job == "Frontend programmer").OrderByDescending(emp => emp.HireDate).Select(x => new
            {
                x.Ename,
                x.Salary
            }).FirstOrDefault();

            var exx = (from emp in Emps
                orderby emp.HireDate descending
                where emp.Job == "Frontend programmer"
                select emp).FirstOrDefault();

            Console.WriteLine(ex);

            Console.WriteLine(exx);
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        public void Przyklad10Button_Click()
        {
            var ex = Emps.Select(x => new
            {
                x.Ename,
                x.Job,
                x.HireDate
            }).Union(new[] { new { Ename = "Brak wartości", Job = (string)null, HireDate = (DateTime?)null } });

            var exx = (from x in Emps
                select new
                {
                    x.Ename,
                    x.Job,
                    x.HireDate
                }).Union(new[] { new { Ename = "Brak wartości", Job = (string)null, HireDate = (DateTime?)null } });

            foreach (var e in ex)
            {
                Console.WriteLine(e);
            }

            foreach (var e in exx)
            {
                Console.WriteLine(e);
            }
        }

        //Znajdź pracownika z najwyższą pensją wykorzystując metodę Aggregate()
        public void Przyklad11()
        {
            var ex = Emps
                .Select(x=>new
                {
                    x.Ename,
                    x.Salary
                })
                .Aggregate((res, next) => res.Salary > next.Salary ? next : res);

            var exx = (from x in Emps
                select x).Aggregate((res, next) => next.Salary > res.Salary ? next : res);

            Console.WriteLine(ex);

            Console.WriteLine(exx);
        }

        //Z pomocą języka LINQ i metody SelectMany wykonaj złączenie
        //typu CROSS JOIN
        public void Przyklad12()
        {
            var ex = Emps.SelectMany(other => Depts, (emp, dept) => new
            {
                emp,
                dept
            });

            var exx = from emp in Emps
                from dept in Depts
                select new
                {
                    emp,
                    dept
                };

            foreach (var e in ex)
            {
                Console.WriteLine(e);
            }

            foreach (var e in exx)
            {
                Console.WriteLine(e);
            }
        }
    }
}