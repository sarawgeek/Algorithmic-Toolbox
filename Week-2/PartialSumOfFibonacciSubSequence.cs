using System;

namespace FibonacciLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var m = int.Parse(input.Split(' ')[0]);
            var n = int.Parse(input.Split(' ')[1]);
            Console.WriteLine(HugeFibonacciNumberModulo(m, n));
        }

        static decimal HugeFibonacciNumberModulo(int m, int n)
        {
            decimal[] fibonacci_sequence = new decimal[n];
            if(n < 1) return 0;
            if(n==1) return 1;
            fibonacci_sequence[0] = 1;
            fibonacci_sequence[1] = 1;
            for(int i = 2; i < n; i++){
                fibonacci_sequence[i] = (fibonacci_sequence[i-1] % 10)
                 + (fibonacci_sequence[i-2] % 10);
            }
            decimal sum = 0;
            if(m==0) m=1;
            for(int i = m - 1; i < n; i++)
            {
                sum+= fibonacci_sequence[i];
            }
            return sum % 10;
        }
    }
}