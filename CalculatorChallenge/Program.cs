using System;

namespace CalculatorChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            FormatOutput format = new FormatOutput();
            Console.WriteLine("Hello World!");

            String input = Console.ReadLine();
            int sum = format.GetNumbersFromArgument(input);
            Console.WriteLine(sum);
        }
    }
}
