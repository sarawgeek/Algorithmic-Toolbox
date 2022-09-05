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
            Console.WriteLine(EuclideanGCD(a,b));
        }

        static int EuclideanGCD(int a, int b)
        {
            if(a == 0) return b;
            if(b == 0) return a;
            if(a > b) return EuclideanGCD(b, a % b);
            else return EuclideanGCD(a, b % a);
        }

    }
}