using System;
using System.Diagnostics;
using static System.Console;


namespace GreedyAlgorithm
{
    public static class Week3PracticeProblems
    {
        public static int MoneyChange(int[] denoms, int Money)
        {
            int leastCount = Int32.MaxValue;
            var watch = new Stopwatch();
            watch.Start();
            for(int i = 0; i < denoms.Length ; i++)
            {
                int currentMoney = Money;
                int currentIndex = i;
                int currentLeastCount = 0;
                while(currentMoney != 0 && currentIndex < denoms.Length)
                {
                    if(currentMoney >= denoms[currentIndex])
                    {
                        currentMoney -= denoms[currentIndex];
                        currentLeastCount++;
                    }
                    else currentIndex++;
                }
                if(leastCount > currentLeastCount) leastCount = currentLeastCount;
            }
            watch.Stop();
            WriteLine($"Total denom count is - {leastCount}");
            WriteLine($"{0:#,##0} elapsed millisecond",
            arg0: watch.ElapsedMilliseconds);

            return leastCount;
        }

        public static int MoneyChangeWithFixedDenom(int money)
        {
            return (money/10) + ((money%10)/5) + ((money%10)%5);
        }
    }
}