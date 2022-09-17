using System;
using Xunit;
using GreedyAlgorithm;

namespace UnitTests.Week3
{
    public class UnitTest
    {
        [Fact]
        public void MoneyExchangeTest1()
        {
            int expected = 2;
            int actual = Week3PracticeProblems.MoneyChange(new int[]{1,5,4,10},28);
            Assert.Equal(expected, actual);          
        }
    }
}
