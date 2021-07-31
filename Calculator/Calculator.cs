using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Calculator
    {
        public double A { get; set; }
        public double B { get; set; }

        public Calculator(double a, double b)
        {
            A = a;
            B = b;
        }

        public static bool CheckOperation(char operation)
        {
            if (operation.Equals('+') || operation.Equals('-') || operation.Equals('*') || operation.Equals('/'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double Calculate(char operation)
        {
            if (operation.Equals('+'))
            {
                return A + B;
            }
            if (operation.Equals('-'))
            {
                return A - B;
            }
            if (operation.Equals('*'))
            {
                return A * B;
            }
            if (operation.Equals('/'))
            {
                return A / B;
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}
