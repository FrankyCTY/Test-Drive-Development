namespace BusinessLogic
{
    public class Greed
    {
        public int RollDices(params int[] dieValues)
        {
            //if (dieValues.Count() < 5) throw new InvalidDiceQuantity();

            var scores = 0;

            for(int dieValue = 1; dieValue < 7; dieValue++)
            {
                var numOfMatchingDice = Array.FindAll(dieValues, (v => v == dieValue)).Count();
                if (numOfMatchingDice is 0) continue;

                var hasTriplet = numOfMatchingDice >= 3;
                var numOfIndividuals = numOfMatchingDice;

                if (hasTriplet)
                {
                    scores += CalculateTripletScores(dieValue);
                    numOfIndividuals = numOfMatchingDice - 3;
                }

                scores += CalculateIndividualScores(dieValue, numOfIndividuals);
            }

            return scores;
        }

        private int CalculateIndividualScores(int dieValue, int numOfIndividuals)
        {
            if (dieValue == 1)
                return 100 * numOfIndividuals;

            if (dieValue == 5)
                return  50 * numOfIndividuals;

            return 0;
        }

        private int CalculateTripletScores(int dieValue)
        {
            if (dieValue == 1)
                return 1000;

            return dieValue * 100;
        }
    }

    public class InvalidDiceQuantity : Exception
    { }
}

