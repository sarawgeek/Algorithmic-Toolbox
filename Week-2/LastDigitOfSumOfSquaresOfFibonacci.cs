using System;

namespace LastDigitOfSumOfSquaresOfFibonacci
{
    class Program111
    {
        static void Main1(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            //var m = int.Parse(input.Split(' ')[0]);
            //var n = int.Parse(input.Split(' ')[1]);
            Console.WriteLine(LastDigitOfSumOfSquaresOfFibonacci(n));
        }

        static decimal LastDigitOfSumOfSquaresOfFibonacci(int n)
        {
            decimal[] fibonacci_sequence = new decimal[n];
            if(n < 1) return 0;
            if(n==1 || n==2) return 1;
            fibonacci_sequence[0] = 1;
            fibonacci_sequence[1] = 1;
            for(int i = 2; i < n; i++){
                fibonacci_sequence[i] = fibonacci_sequence[i-1] + fibonacci_sequence[i-2];
            }
            decimal sum = 0;
            for(int i = 0; i < n; i++)
            {
                sum+= fibonacci_sequence[i] * fibonacci_sequence[i];
            }
            return sum % 10;
        }
    }
}