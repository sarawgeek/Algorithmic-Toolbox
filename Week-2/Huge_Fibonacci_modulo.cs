using System;

namespace Huge_Fibonacci_modulo
{
    class Program24
    {
        static void Main1(string[] args)
        {
            var input = Console.ReadLine();
            var n = long.Parse(input.Split(' ')[0]);
            var m = long.Parse(input.Split(' ')[1]);
            Console.WriteLine(HugeFibonacciNumberModulo(n, m));
        }

        static long HugeFibonacciNumberModulo(long n, long m)
        {
            //decimal[] fibonacci_sequence = new decimal[n];
            //long first = 1;
            long current = 1;
            long previous = 0;
            if(n <= 1) return n;
            //if(n==1 || n==2) return 1;
            //fibonacci_sequence[0] = 1;
            //fibonacci_sequence[1] = 1;
            for (int i = 2; i < n; i++)
            {
                //fibonacci_sequence[i] = (fibonacci_sequence[i-1] + fibonacci_sequence[i-2]) % m;

                long tmp_previous = previous;
                previous = current;
                current = tmp_previous + current;

            }
            return current % m;
        }
    }
}