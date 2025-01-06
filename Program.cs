using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var name = "nagy";

            Console.WriteLine(name.ToBigCase());

            var num = 5;

            Console.WriteLine(num.IsEven());
        }
    }
}
