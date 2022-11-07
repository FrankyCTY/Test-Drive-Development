namespace BusinessLogic
{
    public class Greed
    {
        public int Score(params int[] dieValues)
        {
            if (dieValues.Count() < 5) throw new InvalidDiceQuantity();

            var scores = 0;

            for(int dieValue = 1; dieValue < 7; dieValue++)
            {
                var numOfMatchingDice = Array.FindAll(dieValues, (v => v == dieValue)).Count();
                if (numOfMatchingDice is 0) continue;

                var hasTriplet = numOfMatchingDice >= 3;
                var numOfIndividualDice = numOfMatchingDice;

                if (hasTriplet)
                {
                    scores += ScoreATriplet(dieValue);
                    numOfIndividualDice = numOfMatchingDice - 3;
                }

                scores += ScoreIndividualDie(dieValue) * numOfIndividualDice;
            }

            return scores;
        }

        private int ScoreIndividualDie(int dieValue)
        {
            if (dieValue == 1)
                return 100;

            if (dieValue == 5)
                return  50;

            return 0;
        }

        private int ScoreATriplet(int dieValue)
        {
            if (dieValue == 1)
                return 1000;

            return dieValue * 100;
        }
    }

    public class InvalidDiceQuantity : Exception
    {
        public InvalidDiceQuantity()
            : base("Please provide 5 dice values.")
        {}
    }
}

