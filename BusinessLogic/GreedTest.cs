using FluentAssertions;
using Xunit;

namespace BusinessLogic
{
    public class GreedTest
    {
        [Fact]
        public void Call_Score_Without_5_Dice_Values_Should_Throw_InvalidDiceQuantity_Exception()
        {
            var greed = new Greed();

            Action RollDices = () => greed.Score(1);

            RollDices.Should().ThrowExactly<InvalidDiceQuantity>().WithMessage("Please provide 5 dice values.");
        }

        [Theory]
        [InlineData(1150, 1,1,1,5,1)]
        [InlineData(300, 2,3,3,3,2)]
        [InlineData(500, 3,5,5,5,3)]
        public void Return_Correct_Scores_For_Combination_With_Triplet(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }

        [Theory]
        [InlineData(150, 1,2,3,4,5)]
        [InlineData(250, 1,1,3,4,5)]
        [InlineData(300, 1,1,3,5,5)]
        public void Return_Correct_Scores_For_Combination_Without_Triplet(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }
    }
}