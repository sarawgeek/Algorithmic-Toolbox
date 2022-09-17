using System;

namespace FibonacciNumber
{
    class Program1
    {
        static void Main1(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(NthFibonacciNumber(input));
        }

        static long NthFibonacciNumber(int n)
        {
            int[] fibonacci_sequence = new int[n];
            if(n < 1) return 0;
            if(n==1 || n==2 ) return 1;
            fibonacci_sequence[0] = 1;
            fibonacci_sequence[1] = 1;
            for(int i = 2; i < n; i++){
                fibonacci_sequence[i] = fibonacci_sequence[i-1] + fibonacci_sequence[i-2];
            }
            return fibonacci_sequence[n-1];
        }
    }
}