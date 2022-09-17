using System;

namespace Euclidean
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            var a = decimal.Parse(tokens[0]);
            var b = decimal.Parse(tokens[1]);
            Console.WriteLine(LCM(a,b));
        }

        static decimal GCD(decimal a, decimal b)
        {
            if(a == 0) return b;
            if(b == 0) return a;
            if(a > b) return GCD(b, a % b);
            else return GCD(a, b % a);
        }

        static decimal LCM(decimal a, decimal b)
        {
            return (a*b)/GCD(a,b);
        }

    }
}