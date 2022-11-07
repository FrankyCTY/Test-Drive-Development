using FluentAssertions;
using Xunit;

namespace BusinessLogic
{
    public class GreedTest
    {
        [Theory]
        [InlineData()]
        [InlineData(1,2,3,4,5,6,7)]
        public void Given_Invalid_Amount_Of_Dice_Value_When_Call_Score_Then_Throw_InvalidDiceQuantity_Exception(params int[] dieValues)
        {
            var greed = new Greed();

            Action Score = () => greed.Score(dieValues);

            Score.Should().ThrowExactly<InvalidDiceQuantity>().WithMessage("Please provide at least 1 and up to 6 dice values.");
        }

        [Theory]
        [InlineData(100, 1)]
        [InlineData(50, 5)]
        [InlineData(0, 6)]
        public void Given_Single_Dice_Value_When_Call_Score_Then_Return_Correct_Scores(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }

        [Theory]
        [InlineData(1150, 1,1,1,5,1)]
        [InlineData(300, 2,3,3,3,2)]
        [InlineData(500, 3,5,5,5,3)]
        public void Given_Five_Dice_Values_With_Triplet_Combo_When_Call_Score_Then_Return_Correct_Scores(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }

        [Theory]
        [InlineData(150, 1,2,3,4,5)]
        [InlineData(250, 1,1,3,4,5)]
        [InlineData(300, 1,1,3,5,5)]
        public void Given_Five_Dice_Values_Without_Triplet_Combo_When_Call_Score_Then_Return_Correct_Scores(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }
    }
}