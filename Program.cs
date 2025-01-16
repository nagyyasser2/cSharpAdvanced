using System;
using System.Collections.Generic;

namespace AdvancedCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProcessPatch1();
            ProcessPatch2();

        }

        private static void ProcessPatch1()
        {
            for (int i = 0; i < 1000; i++) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(i);
                Console.ForegroundColor = ConsoleColor.White;
            }
        } 

        private static void ProcessPatch2()
        {
            for (int i = 1001; i < 2000; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(i);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
