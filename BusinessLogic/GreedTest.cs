using System;
using Xunit;

namespace BusinessLogic
{
    public class GreedTest
    {
        [Fact]
        public void Can_Call_Add()
        {
            var greed = new Greed();

            greed.RollDice();
	    }
    }
}