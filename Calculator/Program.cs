using System;
using System.Globalization;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var program = new Program();
                program.Run(args);
            }
        }

        void Run(string[] args)
        {
            Console.WriteLine("Please, enter two digits with space separator");
            var input = Console.ReadLine();

            Console.WriteLine("Please, enter operation. Valid operations are +, - , * , /");
            var operation = Console.ReadLine();

            var numbersString = input.Split(' ');
            if (numbersString.Length != 2)
            {
                Console.WriteLine("Two numbers expected");
                return;
            }
            
            var numbers = numbersString.Select(x => double.Parse(x)).ToList();
            Calculator calculator = new Calculator(numbers[0], numbers[1]);
            if (Calculator.CheckOperation(char.Parse(operation)))
            {
                var result = calculator.Calculate(char.Parse(operation));
                Console.WriteLine("Result " + result.ToString(CultureInfo.InvariantCulture));
            } else
            {
                Console.WriteLine("Result cannot be calculated");
            }
        }
    }
}
