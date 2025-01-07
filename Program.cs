using System;
using System.Collections.Generic;

namespace AdvancedCSharp
{
    public class Program
    {
        delegate bool ShouldCalculate(Employee employee);
        public class Employee
        {
            public string Name { get; set; }
            public int BasicSalary { get; set; }
            public int Deduction { get; set; }
            public int Ponus { get; set; }
        }

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                Employee employee = new Employee
                {
                    Name = i.ToString(),
                    BasicSalary = random.Next(1000, 5001),
                    Deduction = random.Next(0, 501),
                    Ponus = random.Next(0, 1001)
                };
                employees.Add(employee);
            }

            // CalculateSalaries(employees, e=> e.BasicSalary <= 2000);
            CalculateSalaries(employees, e => e.BasicSalary >= 3500);
        }

        private static void CalculateSalaries(List<Employee> employees, ShouldCalculate predicate)
        {
            foreach (var e in employees)
            {
                if (predicate(e))
                {
                    var salary = e.BasicSalary + e.Ponus - e.Deduction;
                    Console.WriteLine($"salary-emp '{e.Name}' : ${salary}");
                }
            }
        }
    }
}
