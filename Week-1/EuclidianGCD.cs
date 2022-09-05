using System;

namespace Euclidean
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            var a = int.Parse(tokens[0]);
            var b = int.Parse(tokens[1]);
            Console.WriteLine(EuclidianGCD(a,b));
        }

        static int EuclidianGCD(int a, int b)
        {
            if(a == 0) return b;
            if(b == 0) return a;
            if(a > b) return EuclidianGCD(b, a % b);
            else return EuclidianGCD(a, b % a);
        }

    }
}