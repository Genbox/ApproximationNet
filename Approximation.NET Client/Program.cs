using System;
using System.Diagnostics;

namespace ApproximationNET
{
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            double result = 0;
            const int iterations = 1000000;

            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                result = Math.Sin(1.5f);
            }
            stopwatch.Stop();

            Console.WriteLine("Real sine value using Math.Sin(1.5f)");
            Console.WriteLine("Value: " + result);
            Console.WriteLine("Time (ms): " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine();

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                result = Approximation.HighSin(1.5f);
            }
            stopwatch.Stop();

            Console.WriteLine("Approximated sine value using quadratic curve (high precision)");
            Console.WriteLine("Value: " + result);
            Console.WriteLine("Time (ms): " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine();

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                result = Approximation.LowSin(1.5f);
            }
            stopwatch.Stop();

            Console.WriteLine("Approximated sine value using quadratic curve (low precision)");
            Console.WriteLine("Value: " + result);
            Console.WriteLine("Time (ms): " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine();

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                result = Approximation.TaylorSin(1.5f);
            }
            stopwatch.Stop();

            Console.WriteLine("Approximated sine value using Taylor series");
            Console.WriteLine("Value: " + result);
            Console.WriteLine("Time (ms): " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine();

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                result = Math.Sqrt(5);
            }
            stopwatch.Stop();

            Console.WriteLine("Real 1/Sqrt(5)");
            Console.WriteLine("Value: " + 1 / result);
            Console.WriteLine("Time (ms): " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine();

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                result = Approximation.InvSqrt(5);
            }
            stopwatch.Stop();

            Console.WriteLine("Approximated 1/Sqrt(5)");
            Console.WriteLine("Value: " + result);
            Console.WriteLine("Time (ms): " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine();

            Console.WriteLine("Press a key to continue.");
            Console.ReadLine();
        }
    }
}
