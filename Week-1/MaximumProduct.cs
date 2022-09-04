using System;
using System.Linq;

namespace MaximumProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var arr = input.Split(' ').Select(long.Parse).ToArray();
            if(count != arr.Length) Console.WriteLine(0);
            else Console.WriteLine(GetMaximumProduct(arr));
        }

        static long GetMaximumProduct(long[] arr)
        {
            long maxElem = 0, secondMax = 0; int index = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(maxElem < arr[i])
                {
                    maxElem = arr[i];
                    index = i;
                } 
            }

            for(int j = 0; j < arr.Length; j++)
            {
                if(secondMax < arr[j] && j != index) secondMax = arr[j];
            }

            return maxElem * secondMax;
        }
    }
}
