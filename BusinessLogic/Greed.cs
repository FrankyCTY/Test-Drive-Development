namespace BusinessLogic
{
    public class Greed
    {
        public int Score(params int[] dieValues)
        {
            if (dieValues.Count() == 0 || dieValues.Count() > 6) throw new InvalidDiceQuantity();

            var result = 0;
            result += ScoreTriplet(dieValues);
            result += ScoreIndividual(dieValues);

            return result;
        }

        private int ScoreIndividual(params int[] dieValues)
        {
            var result = 0;
            for(int dieValue = 1; dieValue < 7; dieValue++)
            {
                var numOfMatchingDice = dieValues.Where(v => v == dieValue).Count();
                var hasTriplet = numOfMatchingDice >= 3;
                var numOfIndividuals = hasTriplet ? numOfMatchingDice - 3 : numOfMatchingDice;

                if (dieValue == 1)
                 result += 100 * numOfIndividuals;

                if (dieValue == 5)
                 result +=  50 * numOfIndividuals;
            }

            return result;
        }

        private int ScoreTriplet(params int[] dieValues)
        {
            var result = 0;
            for(int dieValue = 1; dieValue < 7; dieValue++)
            {
               var numOfMatchingDice = dieValues.Where(v => v == dieValue).Count();
               var hasTriplet = numOfMatchingDice >= 3;

               if (!hasTriplet) continue;

               if (dieValue == 1)
                  result += 1000;
               else
                 result += dieValue * 100;
            }

            return result;
        }
    }

    public class InvalidDiceQuantity : Exception
    {
        public InvalidDiceQuantity()
            : base("Please provide at least 1 and up to 6 dice values.")
        {}
    }
}

