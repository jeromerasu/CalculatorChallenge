using System;

namespace CalculatorChallenge
{
    /// <summary>
    /// Driver for Calculator Class, when tryin
    /// </summary>
    class Program
    {
        private static volatile bool stop = false;
        private static int defaultOrCustom;
        private static Boolean allowNegativeNumbers;
        private static int upperBound;
        private static String newCustomDelimiter;
        private static int operation;
        static void Main(string[] args)
        {
            FormatOutput format = new FormatOutput();

            Console.CancelKeyPress += new ConsoleCancelEventHandler(CancelKeyPress);
            Console.WriteLine("Welcome User!");
            ProcessDefaultOrNo();
            if (defaultOrCustom == 1)
            {
                DefaultOperation();
            }
            else
            {
                CustomCalculator();
            }
        }
        private static void CustomCalculator()
        {
            Console.WriteLine("Press Y to allow negative numbers");
            allowNegativeNumbers = Console.ReadLine() == "Y";
            ProcessAltDelim();
            ProcessUpperBound();
            ProcessDifferentOperation();
            while (!stop)
            {

                Console.WriteLine("Input values to calculate ");
                Console.WriteLine("Press control c to exit");
                String input = Console.ReadLine();
                //Additional step to prevent anymore calculations
                if (stop == true)
                {
                    break;
                }
                FormatOutput format = new FormatOutput();
                CalculateOutputLine calculation = format.GetNumbersFromArgument(input, allowNegativeNumbers, newCustomDelimiter, upperBound, operation, true);
                if (calculation != null)
                {
                    Console.WriteLine($"Formula was : {calculation.Formula} ");
                    Console.WriteLine($"Total was : {calculation.Total}");
                }
                


            }
        }
        private static void DefaultOperation()
        {

            while (!stop)
            {

                Console.WriteLine("Input values to calculate ");
                Console.WriteLine("Press control c to exit");
                String input = Console.ReadLine();
                //Additional step to prevent anymore calculations
                if (stop == true)
                {
                    break;
                }
                FormatOutput format = new FormatOutput();              
                CalculateOutputLine calculation = format.GetNumbersFromArgument(input, false, Environment.NewLine, 1000, 1, true);
                if (calculation != null)
                {
                    Console.WriteLine($"Formula was : {calculation.Formula} ");
                    Console.WriteLine($"Total was : {calculation.Nums}");
                }

            }
        }
        private static void ProcessDefaultOrNo()
        {
            while (true)
            {
                Console.WriteLine("Enter 1 for Default, 2 for Custom");
                String tempInput = Console.ReadLine();
                int temp;
                if (Int32.TryParse(tempInput, out temp) && temp == 1 || temp == 2)
                {
                    defaultOrCustom = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Please input valid number");
                }
            }
        }
        private static void ProcessDifferentOperation()
        {
            while (true)
            {
                Console.WriteLine("Enter 1 for Add, 2 for Subtract, 3 for Multiplication, 4 for Division");
                String tempInput = Console.ReadLine();
                int temp;
                if (Int32.TryParse(tempInput, out temp) && temp == 1 || temp == 2 || temp == 3 || temp == 4)
                {
                    if (temp == 2)
                    {
                        allowNegativeNumbers = true;
                    }
                    operation = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Please input valid number as upper bound");
                }
            }
        }
        private static void ProcessAltDelim()
        {
            while (true)
            {
                Console.WriteLine("Enter an alternate delimiter otherwise press enter to have new line be default delimiter");
                newCustomDelimiter = Console.ReadLine();
                int temp;
                if (Int32.TryParse(newCustomDelimiter, out temp))
                {
                    Console.WriteLine("Can't input number as delimiter");
                }
                else
                {
                    if (newCustomDelimiter == null || newCustomDelimiter.Length == 0)
                    {
                        newCustomDelimiter = Environment.NewLine;
                    }
                    break;
                }
            }
        }

        private static void ProcessUpperBound()
        {
            while (true)
            {
                Console.WriteLine("Enter an alternate upperbound otherwise press . to have 1000 be default upper bound");
                String tempInput = Console.ReadLine();
                int temp;
                if (Int32.TryParse(tempInput, out temp))
                {
                    upperBound = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Please input valid number as upper bound");
                }
            }
        }
        static void CancelKeyPress(object sender, ConsoleCancelEventArgs c)
        {
            c.Cancel = true;
            stop = true;
            Console.WriteLine($"Calculator is now exiting");
        }
    }
}
