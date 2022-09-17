using System;

namespace FibonacciLastDigit
{
    class Program11
    {
        static void Main1(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(NthFibonacciNumber(input));
        }

        static decimal NthFibonacciNumber(int n)
        {
            decimal[] fibonacci_sequence = new decimal[n];
            if(n < 1) return n;
            //if(n==1 || n==2) return 1;
            fibonacci_sequence[0] = 1;
            fibonacci_sequence[1] = 1;
            for(int i = 2; i < n; i++){
                fibonacci_sequence[i] = (fibonacci_sequence[i-1] + fibonacci_sequence[i-2])%10;
                //Console.WriteLine($"{i} - {fibonacci_sequence[i]}");
            }
            return fibonacci_sequence[n-1];
        }
    }
}