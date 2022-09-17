using System;

namespace FibonacciLastDigit
{
    class Program2
    {
        static void Main1(string[] args)
        {
            var input = long.Parse(Console.ReadLine());
            Console.WriteLine(SumFibonacciNumbersLastDigit(input));
        }

        static decimal SumFibonacciNumbersLastDigit(long n)
        {
            //decimal[] fibonacci_sequence = new decimal[n];
            long first = 1;
            long second = 1;
            long final = 0;
            if(n <= 1) return n;
            //if(n==1 || n==2) return 1;
            //fibonacci_sequence[0] = 1;
            //fibonacci_sequence[1] = 1;
            for(int i = 2; i < n; i++){
                final = (first + second);
                first = second;
                second = final;
                //fibonacci_sequence[i] = (fibonacci_sequence[i-1] + fibonacci_sequence[i-2]) % 10;
            }
            decimal sum = 0;
            //foreach(var item in fibonacci_sequence) sum += item;
            return sum % 10;
        }
    }
}