using System;
using System.Collections.Generic;

namespace AdvancedCSharp
{
    public class Program
    {
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

            SalaryCalculator salaryCalculator = new SalaryCalculator();

            salaryCalculator.EmployeeSalaryCalculated += LogEmployeeSalary;
            salaryCalculator.EmployeeSalaryCalculated += (e,s)=> Console.WriteLine($"Payslip sent to employee `{s}`");

            salaryCalculator.CalculateSalaries(employees, e => e.BasicSalary >= 3500);
  
        }

        private static void LogEmployeeSalary(Employee employee, int salary)
        {
            Console.WriteLine($"{employee.Name}, has salary: {salary}");
        }
    }
}
