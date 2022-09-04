using System;

namespace APlusB
{
    class Program1
    {
        static void Main1(string[] args)
        {
            var input = Console.ReadLine();
            var tokens = input.Split(" ");
            var a = int.Parse(tokens[0]);
            var b = int.Parse(tokens[1]);
            Console.WriteLine(a + b);
        }
    }
}
