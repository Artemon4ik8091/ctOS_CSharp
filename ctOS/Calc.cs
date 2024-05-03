using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctOS
{
    internal class Calc
    {
        public void CalcMain()
        {
            System.Console.WriteLine("Calculator. Select operand (+, -, *, /):");
            var work = System.Console.ReadLine();
            System.Console.WriteLine("Enter first number:");
            double a = Convert.ToDouble(System.Console.ReadLine());
            System.Console.WriteLine("Enter second number:");
            double b = Convert.ToDouble(System.Console.ReadLine());
            double c = 0;
            switch (work)
            {
                default:
                    System.Console.WriteLine("Unknown operand.");
                    break;
                case "+":
                    c = a + b;
                    System.Console.WriteLine("Result: " + c);
                    break;
                case "-":
                    c = a - b;
                    System.Console.WriteLine("Result: " + c);
                    break;
                case "*":
                    c = a * b;
                    System.Console.WriteLine("Result: " + c);
                    break;
                case "/":
                    c = a / b;
                    System.Console.WriteLine("Result: " + c);
                    break;
            }
        }
    }
}
