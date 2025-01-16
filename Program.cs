using System;
using System.Collections.Generic;

namespace AdvancedCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
          var employee = new Employee();

            employee.AddPayItem("Basic", 3000);
            employee.AddPayItem("Housing", 499);
            employee.AddPayItem("Insurence", -500);
            employee.AddPayItem("Transportation", 1000);


            foreach (var payItem in employee) {
                Console.WriteLine($"{payItem.Name} = {payItem.Value}");
            }
        }
    }
}
