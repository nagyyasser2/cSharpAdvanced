using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    public class SalaryCalculator
    {
        public delegate bool ShouldCalculate(Employee employee);

        public event EmployeeSalaryCalculatedEventHandler EmployeeSalaryCalculated;

        public delegate void EmployeeSalaryCalculatedEventHandler(Employee employee, int salary);

        public void CalculateSalaries(List<Employee> employees, ShouldCalculate predicate)
        {
            foreach (var e in employees)
            {
                if (predicate(e))
                {
                    var salary = e.BasicSalary + e.Ponus - e.Deduction;

                    EmployeeSalaryCalculated?.Invoke(e, salary);

                }
            }
        }
    }
}
