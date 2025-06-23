using System;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter current value:");
            double currentValue = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter annual growth rate (as percentage):");
            double rate = Convert.ToDouble(Console.ReadLine()) / 100;

            Console.WriteLine("Enter number of years to forecast:");
            int years = Convert.ToInt32(Console.ReadLine());

            double result = ForecastValue(currentValue, rate, years);
            Console.WriteLine($"\n Predicted value after {years} years: {result:F2}");

            Console.WriteLine("\n Optimized (with memoization):");
            double optimizedResult = ForecastValueMemo(currentValue, rate, years, new double?[years + 1]);
            Console.WriteLine($"Predicted value after {years} years: {optimizedResult:F2}");
        }

        static double ForecastValue(double value, double rate, int years)
        {
            if (years == 0)
                return value;

            return ForecastValue(value, rate, years - 1) * (1 + rate);
        }

        static double ForecastValueMemo(double value, double rate, int years, double?[] memo)
        {
            if (years == 0)
                return value;

            if (memo[years] != null)
                return memo[years].Value;

            memo[years] = ForecastValueMemo(value, rate, years - 1, memo) * (1 + rate);
            return memo[years].Value;
        }
    }
}
