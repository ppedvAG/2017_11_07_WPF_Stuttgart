using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesInPraxis
{
    internal delegate bool MyDelegate(Employee employee);
    // Action       -> void
    // Predicate    -> bool
    // Func

    class Program
    {
        static void Main(string[] args)
        {
            var employees = GetData();

            //MyDelegate del = new MyDelegate(Bedingung);
            //Func<Employee, bool> del = new Func<Employee, bool>(Bedingung);
            //var del = new Func<Employee, bool>(Bedingung);
            //Func<Employee, bool> del = Bedingung;
            //var query = Abfrage(employees, del);

            //var query = Abfrage(employees, Bedingung);

            //var query = Abfrage(employees, delegate (Employee e)
            //{
            //    return e.Name.StartsWith("A");
            //});

            //var query = Abfrage(employees, (Employee e) =>
            //{
            //    return e.Name.StartsWith("A");
            //});

            //var query = Abfrage(employees, (e) =>
            //{
            //    return e.Name.StartsWith("A");
            //});

            //var query = Abfrage(employees, (e) => e.Name.StartsWith("A"));
            var query = employees.Abfrage(e => e.Name.StartsWith("A"));
            var linq = employees.Where(Bedingung);

            foreach (var e in query)
                Console.WriteLine($"Id: {e.Id,2} | {e.Name,-10} | {e.Experience}");
            Console.ReadKey();
        }
        
        private static bool Bedingung(Employee e) => e.Name.StartsWith("A");
        
        private static IEnumerable<Employee> GetData() => new List<Employee>
        {
            new Employee { Id = 1, Name = "Sepp", Experience = 8 },
            new Employee { Id = 2, Name = "Lisa", Experience = 1 },
            new Employee { Id = 3, Name = "Jonas", Experience = 5 },
            new Employee { Id = 4, Name = "Maria", Experience = 6 },
            new Employee { Id = 5, Name = "Luis", Experience = 3 },
            new Employee { Id = 6, Name = "Andrea", Experience = 8 },
            new Employee { Id = 7, Name = "Hannes", Experience = 9 },
            new Employee { Id = 8, Name = "Max", Experience = 10 },
            new Employee { Id = 9, Name = "Janosch", Experience = 4 }
        };
    }

    internal static class Extentions
    {
        public static IEnumerable<T> Abfrage<T>(
           this IEnumerable<T> source,
           Func<T, bool> predicate)
        {
            foreach (var e in source)
                if (predicate(e))
                    yield return e;
        }
    }
}
