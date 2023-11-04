using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator<int> intCalculator = new Calculator<int>((a, b) => a + b, (a, b) => a - b, (a, b) => a * b, (a, b) => a / b);

            int result1 = intCalculator.Add(5, 3);
            int result2 = intCalculator.Subtract(8, 2);
            int result3 = intCalculator.Multiply(4, 7);
            int result4 = intCalculator.Divide(10, 2);

            Console.WriteLine($"Addition result: {result1}");
            Console.WriteLine($"Subtraction result: {result2}");
            Console.WriteLine($"The result of multiplication: {result3}");
            Console.WriteLine($"The result of division: {result4}");

            Calculator<double> doubleCalculator = new Calculator<double>((a, b) => a + b, (a, b) => a - b, (a, b) => a * b, (a, b) => a / b);

            double result5 = doubleCalculator.Add(5.5, 3.2);
            double result6 = doubleCalculator.Subtract(8.6, 2.1);
            double result7 = doubleCalculator.Multiply(4.3, 7.0);
            double result8 = doubleCalculator.Divide(10.0, 3.0);

            Console.WriteLine($"Addition result: {result5}");
            Console.WriteLine($"Subtraction result: {result6}");
            Console.WriteLine($"The result of multiplication: {result7}");
            Console.WriteLine($"The result of division: {result8}");
        }
    }
}