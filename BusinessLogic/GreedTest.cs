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

        [Fact]
        public void Given_Invalid_Dice_Value_When_call_Score_Then_Throw_InvalidDieValue_Exception()
        {
            var greed = new Greed();

            Action Score = () => greed.Score(9,1,2,3,4,8);

            Score.Should().ThrowExactly<InvalidDieValue>().WithMessage("Please provide dice with value from 1 to 6.");
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
        [InlineData(1050, 1, 3, 1, 5, 1)]
        [InlineData(300, 2, 3, 3, 3, 2)]
        [InlineData(500, 3, 5, 5, 5, 3)]
        public void Given_Five_Dice_Values_With_Triplet_Combo_When_Call_Score_Then_Return_Correct_Scores(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }

        [Theory]
        [InlineData(150, 1, 2, 3, 4, 5)]
        [InlineData(250, 1, 1, 3, 4, 5)]
        [InlineData(300, 1, 1, 3, 5, 5)]
        public void Given_Five_Dice_Values_Without_Triplet_Combo_When_Call_Score_Then_Return_Correct_Scores(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }

        [Theory]
        [InlineData(1000 * 2, 1,1,1,3,1,3)]
        [InlineData(200 * 2, 2,2,2,3,2,3)]
        [InlineData(600 * 2, 6,6,6,3,6,3)]
        public void Given_Six_Dice_Values_With_Four_Of_A_Kind_When_Call_Score_Then_Return_Correct_Scores(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }

        [Theory]
        [InlineData(1000 * 4, 1,1,1,1,1,3)]
        [InlineData(200 * 4, 2,2,2,2,2,3)]
        [InlineData(600 * 4, 6,6,6,6,6,3)]
        public void Given_Six_Dice_Values_With_Five_Of_A_Kind_When_Call_Score_Then_Return_Correct_Scores(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }

        [Theory]
        [InlineData(1000 * 8, 1,1,1,1,1,1)]
        [InlineData(200 * 8, 2,2,2,2,2,2)]
        [InlineData(600 * 8, 6,6,6,6,6,6)]
        public void Given_Six_Dice_Values_With_Six_Of_A_Kind_When_Call_Score_Then_Return_Correct_Scores(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }

        [Theory]
        [InlineData(800, 2,2,3,3,4,4)]
        [InlineData(800, 1,1,3,3,6,6)]
        public void Given_Six_Dice_Values_With_Three_Pairs_When_Call_Score_Then_Return_Correct_Scores(int expectedScores, params int[] dieValues)
        {
            var greed = new Greed();

            var actualScores = greed.Score(dieValues);

            actualScores.Should().Be(expectedScores);
        }

        [Fact]
        public void Given_Six_Dice_Values_With_Straight_When_Call_Score_Then_Return_Correct_Scores()
        {
            var greed = new Greed();

            var actualScores = greed.Score(1,2,3,4,5,6);

            actualScores.Should().Be(1200);
        }
    }
}