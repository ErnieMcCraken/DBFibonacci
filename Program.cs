using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DBFibonacci
{
    class Program
    {
        public static int index = 0;
        public static Dictionary<int, int> memo;
        public static long[] f;

        public static void Main(string[] args)
        {
            //BenchmarkRunner.Run<FibonacciBenchmark>();
            FibonacciBenchmark fib = new FibonacciBenchmark();
            while (DateTime.Now > DateTime.Now.AddDays(-1)) {
                fib.Run();
            };
        }


    }
    public class FibonacciBenchmark
    {
        public static int index = 0;
        public static Dictionary<int, int> memo;
        public static long[] f;
        public  void Run()
        {

            int num = 100;
            var stopwatch = new Stopwatch();
            memo = new Dictionary<int, int>();
            f = new long[num + 2];


            Console.WriteLine($"The {num}th fibonacci number.");
            stopwatch.Start();
            var number = Fibonacci();
            Console.WriteLine($"Number: {number} - Time (miliseconds) : {stopwatch.ElapsedTicks} - {index} times");
            stopwatch.Stop();
            stopwatch.Reset();

            index = 0;
            stopwatch.Start();
            number = Fibonacci2();
            Console.WriteLine($"Number: {number} - Time (miliseconds) : {stopwatch.ElapsedTicks} - {index} times");
            stopwatch.Stop();
            stopwatch.Reset();

            //stopwatch.Start();
            //number = Fibonacci3(num);
            //Console.WriteLine($"Number: {number} - Time (miliseconds) : {stopwatch.ElapsedTicks} - {index} times");
            //stopwatch.Stop();
        }

        [Benchmark]
        public long Fibonacci()
        {
            int n = 100;
            int[] f = new int[n + 3];
            int i;

            /* 0th and 1st number of the
               series are 0 and 1 */
            f[0] = 0;
            f[1] = 1;

            for (i = 2; i <= n; i++)
            {
                /* Add the previous 2 numbers
                   in the series and store it */
                f[i] = f[i - 1] + f[i - 2];
                index++;
            }
            return f[n];
        }

        [Benchmark]
        public long Fibonacci2()
        {
            int n = 100;
            long a = 0, b = 1, c = 0;

            // To return the first Fibonacci number
            if (n == 0) return a;

            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
                index++;
            }

            return b;
        }

        [Benchmark]
        public long Fibonacci4()
        {
            int n = 100;

            int[] f = new int[n + 3];
            /* 0th and 1st number of the
               series are 0 and 1 */
            f[0] = 0;
            f[1] = 1;

            Parallel.For(2, n, (i) =>
            {
                /* Add the previous 2 numbers
                   in the series and store it */
                f[i] = f[i - 1] + f[i - 2];
                index++;
            });
            return f[n];

        }

        public long Fibonacci3(int n)
        {
            int[,] F = new int[,]{{1, 1},
                      {1, 0}};
            if (n == 0)
                return 0;
            power(F, n - 1);

            return F[0, 0];
        }

        public static void multiply(int[,] F,
                             int[,] M)
        {
            int x = F[0, 0] * M[0, 0] +
                    F[0, 1] * M[1, 0];
            int y = F[0, 0] * M[0, 1] +
                    F[0, 1] * M[1, 1];
            int z = F[1, 0] * M[0, 0] +
                    F[1, 1] * M[1, 0];
            int w = F[1, 0] * M[0, 1] +
                    F[1, 1] * M[1, 1];

            F[0, 0] = x;
            F[0, 1] = y;
            F[1, 0] = z;
            F[1, 1] = w;
        }

        /* Optimized version of
        power() in method 4 */
        public static void power(int[,] F, int n)
        {
            if (n == 0 || n == 1)
                return;
            int[,] M = new int[,]{{1, 1},
                      {1, 0}};

            power(F, n / 2);
            multiply(F, F);

            if (n % 2 != 0)
                multiply(F, M);
        }
    }
}
