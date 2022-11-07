using FluentAssertions;
using Xunit;

namespace BusinessLogic
{
    public class GreedTest
    {
        //[Fact]
        //public void Given_RollDices_Is_Called_When_Less_Then_5_DiceValues_Passed_In_Then_Throw_InvalidDiceQuantity()
        //{
        //    var greed = new Greed();

        //    Action RollDices = () => greed.RollDices(1);

        //    RollDices.Should().ThrowExactly<InvalidDiceQuantity>();
        //}

        [Theory]
        [InlineData(100, 1)]
        [InlineData(50, 5)]
        [InlineData(0, 6)]
        public void Given_Single_Die_When_Rolled_Then_Return_Correct_Scores(int expectedPoints, int dieValue)
        {
            var greed = new Greed();

            var actualScores = greed.RollDices(dieValue);

            actualScores.Should().Be(expectedPoints);
        }

        [Theory]
        [InlineData(1000, 1,1,1)]
        [InlineData(200, 2,2,2)]
        [InlineData(300, 3,3,3)]
        [InlineData(500, 5,5,5)]
        [InlineData(600, 6,6,6)]
        public void Given_3_dices_When_Rolled_Triplet_Values_Then_Return_Correct_Scores(int expectedPoints, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.RollDices(dieValues);

            actualScores.Should().Be(expectedPoints);
        }

        [Theory]
        [InlineData(200, 2,2,2,2,2)]
        [InlineData(1200, 1,1,1,1,1)]
        [InlineData(600, 5,5,5,5,5)]
        [InlineData(600, 6,6,6,6,6)]
        public void Given_5_Dice_With_Same_Value_When_Rolled_Then_Return_Correct_Scores(int expectedPoints, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.RollDices(dieValues);

            actualScores.Should().Be(expectedPoints);
        }

        [Theory]
        [InlineData(1150, 1,1,1,5,1)]
        [InlineData(0, 2,3,4,6,2)]
        [InlineData(350, 3,4,5,3,3)]
        public void Given_5_dices_When_Rolled_Then_Return_Correct_Scores(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.RollDices(dieValues);

            actualScores.Should().Be(expectedScores);
        }
    }
}