using System;
using System.Linq;

namespace ProblemsToSubmit
{
    class Program
    {
        static void Main(string[] args)
        {
            //int money = int.Parse(Console.ReadLine());
#region Maximum Loot Input
            var input = Console.ReadLine();
            int numberOfCompounds = int.Parse(input.Split(' ')[0]);
            int bagWeightLimit = int.Parse(input.Split(' ')[1]);
            //int[,] WiVi = new int[compounds,2];
            int[] weights = new int[numberOfCompounds];
            decimal[] values = new decimal[numberOfCompounds];
            int totalWeight = 0;
            for(int i = 0; i < numberOfCompounds; i++)
            {
                var tempInput = Console.ReadLine();
                values[i] = decimal.Parse(tempInput.Split(' ')[0]);
                weights[i] = int.Parse(tempInput.Split(' ')[1]);
                //Console.WriteLine($"value = {values[i]}, weight = {weights[i]}");
                values[i] = values[i]/weights[i];
                totalWeight += weights[i];
            }

            Console.WriteLine(MaximumLootNew(bagWeightLimit, weights, values, totalWeight));
#endregion

            /* // Input for Car Fueling problem
            var totalDistance = int.Parse(Console.ReadLine());
            var carMilesCapacity = int.Parse(Console.ReadLine());
            var totalHops = int.Parse(Console.ReadLine());
            int[] hops = new int[totalHops+1];
            hops = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            hops[hops.Length - 1] = totalDistance;
            Console.WriteLine(MinimumHops(carMilesCapacity, hops, totalDistance)); */

            //Input for Maximum Revenue
            /* var input = int.Parse(Console.ReadLine());
            int[] price = new int[input];
            int[] clicks = new int[input];
            price = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            clicks = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(MaximmunRevenue(price, clicks)); */

            // Input for Max Salary
            /* var input = int.Parse(Console.ReadLine());
            int[] numbers = new int[input];
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(MaximumSalary(numbers)); */
        }

        public static float MaximumLoot(int maxWeightCanCarry, int[] weights, int[] values, int totalWeightAvailableForLoot)
        {
            //int[,] val = MaxValueAndQuantity(compounds);
            float loot = 0.0f;
            
            while (maxWeightCanCarry > 0 && totalWeightAvailableForLoot > 0)
            {
                //int[,] maxValue = new int[1, 2];
                int currentIndex = weights.Length - 1;
                int indexOfMaxValue = -1;
                float currentMax = float.MinValue;
                while (currentIndex >= 0)
                {
                    if (weights[currentIndex] != 0)
                    {
                        float u = float.MinValue;
                        if(maxWeightCanCarry > weights[currentIndex]) u = weights[currentIndex];
                        else u = maxWeightCanCarry;

                        float currentCal = values[currentIndex] * (u / weights[currentIndex]);
                        
                        //Console.WriteLine($"currentCal = {currentCal}, elementValue = {values[currentIndex]}, weights = {weights[currentIndex]}, maxweightofBagNow = {maxWeightCanCarry}");
                        
                        if (currentMax < currentCal)
                        {
                            currentMax = currentCal;
                            //maxValue[0, 0] = compounds[length - 1, 0];
                            //maxValue[0, 1] = compounds[length - 1, 1];
                            indexOfMaxValue = currentIndex;
                        }
                    }

                    currentIndex--;
                }
                //Console.WriteLine($"index = {indexOfMaxValue}, MaxWeight = {currentMax}, maxweightCanCarry = {maxWeightCanCarry}, totalAvailableforLoot = {totalWeightAvailableForLoot}");

                if (maxWeightCanCarry < weights[indexOfMaxValue])
                {
                    loot+= currentMax;//maxValue[0,0];//maxValue[0, 0] * maxWeightCanCarry;
                    return loot;
                }
                else
                {
                    loot+= currentMax; //maxValue[0, 0];//maxValue[0, 0] * maxValue[0, 1];
                    maxWeightCanCarry -= weights[indexOfMaxValue];
                    totalWeightAvailableForLoot -= weights[indexOfMaxValue];
                    values[indexOfMaxValue] = 0;
                    weights[indexOfMaxValue] = 0;
                }
            }
            //Console.WriteLine($"Value = {val[0,0]}, weight = {val[0,1]}");
            return loot;
        }

        public static decimal MaximumLootNew(int bagWeightCapacity, int[] weights, decimal[] values, int totalWeightAvailableForLoot)
        {
            decimal maxLoot = 0.0m;
            if(totalWeightAvailableForLoot <= bagWeightCapacity) return GetTotalValue(values, weights);
            else
            {
                while(bagWeightCapacity > 0)
                {
                    int index = GetMaxValueIndex(values);
                    if(bagWeightCapacity <= weights[index])
                    {
                        maxLoot+= values[index] * bagWeightCapacity;
                        return Math.Round(maxLoot, 4);
                    }
                    else
                    {
                        maxLoot+= values[index] * weights[index];
                        bagWeightCapacity-= weights[index];
                        values[index] = 0.0m;
                    }
                }
            }
            return Math.Round(maxLoot, 4);
        }

        public static int GetMaxValueIndex(decimal[] values)
        {
            decimal value = decimal.MinValue;
            int index = -1;

            for(int i = 0; i < values.Length; i++)
            {
                if(value < values[i])
                {
                    value = values[i];
                    index = i;
                }
            }
            return index;
        }

        public static decimal GetTotalValue(decimal[] values, int[] weights)
        {
            decimal totalValue = 0.0m;
            for(int i = 0; i < values.Length; i++)
            {
                totalValue+= values[i] * weights[i];
            }
            //Console.WriteLine($"Total Value = {totalValue}");
            //Console.WriteLine($"Total Value rounded = {Math.Round(totalValue, 4)}");
            return Math.Round(totalValue, 4);
        }

        public static int MinimumHops(int carMilesCapacity, int[] hops, int totalDistance)
        {
            int previousMilestone = 0;
            int lastHop = 0;
            int totalHops = 0;

            if(hops[hops.Length -1] <= carMilesCapacity) return 0;

            for(int i = 0; i < hops.Length; i++)
            {
                if(totalDistance - lastHop <= carMilesCapacity) return totalHops;

                if(hops[i] - previousMilestone > carMilesCapacity || previousMilestone - lastHop > carMilesCapacity)
                return -1;

                if(hops[i] - lastHop > carMilesCapacity)
                {
                    lastHop = previousMilestone;
                    totalHops++;
                }
                previousMilestone = hops[i];
            }
            return totalHops;

            //if(totalDistance <= carMilesCapacity) return 0;

        }

        
        public static long MaximmunRevenue(int[] price, int[] clicks)
        {
            Array.Sort(price);
            Array.Sort(clicks);
            long maxRevenue = 0;
            for(int i = 0; i< price.Length; i++)
            {
                maxRevenue += (long)price[i] * clicks[i];
            }
            return maxRevenue;
        }

        public static int MaximumSalary(int[] numbers)
        {
            int maxNumber = numbers[0];
            for(int i = 1; i < numbers.Length; i++)
            {
                if(IsBetter(maxNumber, numbers[i]))
                {
                    maxNumber  = Append(maxNumber, numbers[i]);
                }
                else maxNumber = Append(numbers[i], maxNumber);
            }
            return maxNumber;
        }

        public static bool IsBetter(int n1, int n2)
        {
            int first = Append(n1, n2);;
            int second = Append(n2, n1);
            return (first > second);
        }

        public static int Append(int n1, int n2)
        {
            return int.Parse(n1.ToString() + n2.ToString());
        }

        /* public static int CollectingSignatures(List<int[]> points)
        {
            int uniqueSets = 0;
            

        } */
    }
}
