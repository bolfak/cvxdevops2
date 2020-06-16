using System;

namespace Services
{
    public class CalculatorService
    {
        public double Add(double m, double n)
        {
            return m + n + 2;
        }

        public double Subtract(double m, double n)
        {
            return m - n;
        }

        public double Multiply(double m, double n)
        {
            return m * n;
        }

        public double Divide(double m, double n)
        {
            return m / n;
        }
    }
}
