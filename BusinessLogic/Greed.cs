namespace BusinessLogic
{
    public class Greed
    {
        public int Score(params int[] dieValues)
        {
            if (dieValues.Count() == 0 || dieValues.Count() > 6) throw new InvalidDiceQuantity();

            var result = 0;

            result += ScoreStraight(dieValues);
            // has straight
            if (result > 0) return result;

            result += ScoreThreePairs(dieValues);
            // has 3 pairs
            if (result > 0) return result;

            result += ScoreComboDice(dieValues);
            result += ScoreNonComboDice(dieValues);

            return result;
        }

        private int ScoreNonComboDice(params int[] dieValues)
        {
            var result = 0;
            for(int dieValue = 1; dieValue < 7; dieValue++)
            {
                var numOfMatchingDice = dieValues.Where(v => v == dieValue).Count();
                var hasCombo = numOfMatchingDice >= 3;

                // FIXME: 3 pairs combo is not yet recognized as combo in here
                if (hasCombo || numOfMatchingDice is 0) continue;

                if (dieValue == 1)
                 result += 100 * numOfMatchingDice;

                if (dieValue == 5)
                 result +=  50 * numOfMatchingDice;
            }

            return result;
        }

        private int ScoreComboDice(params int[] dieValues)
        {
            var result = 0;
            result += ScoreTriplet(dieValues);
            result += ScoreFourOfAKind(dieValues);
            result += ScoreFiveOfAKind(dieValues);
            result += ScoreSixOfAKind(dieValues);
            //result += ScoreThreePairs(dieValues);

            return result;
        }

        private int ScoreTriplet(params int[] dieValues)
        {
            var result = 0;
            for(int dieValue = 1; dieValue < 7; dieValue++)
            {
               var numOfMatchingDice = dieValues.Where(v => v == dieValue).Count();
               var hasTriplet = numOfMatchingDice == 3;

               if (!hasTriplet) continue;

               if (dieValue == 1)
                  result += 1000;
               else
                 result += dieValue * 100;
            }

            return result;
        }

        private int ScoreFourOfAKind(params int[] dieValues)
        {
            var result = 0;
            for(int dieValue = 1; dieValue < 7; dieValue++)
            {
               var numOfMatchingDice = dieValues.Where(v => v == dieValue).Count();
               var hasFourOfAKind = numOfMatchingDice == 4;

               if (!hasFourOfAKind) continue;

               if (dieValue == 1)
                  result += 1000 * 2;
               else
                 result += dieValue * 100 * 2;
            }

            return result;
        }

        private int ScoreFiveOfAKind(params int[] dieValues)
        {
            var result = 0;
            for (int dieValue = 1; dieValue < 7; dieValue++)
            {
                var numOfMatchingDice = dieValues.Where(v => v == dieValue).Count();
                var hasFourOfAKind = numOfMatchingDice == 5;

                if (!hasFourOfAKind) continue;

                if (dieValue == 1)
                    result += 1000 * 4;
                else
                    result += dieValue * 100 * 4;
            }

            return result;
        }

        private int ScoreSixOfAKind(params int[] dieValues)
        {
            var result = 0;
            for (int dieValue = 1; dieValue < 7; dieValue++)
            {
                var numOfMatchingDice = dieValues.Where(v => v == dieValue).Count();
                var hasFourOfAKind = numOfMatchingDice == 6;

                if (!hasFourOfAKind) continue;

                if (dieValue == 1)
                    result += 1000 * 8;
                else
                    result += dieValue * 100 * 8;
            }

            return result;
        }

        private int ScoreThreePairs(params int[] dieValues)
        {
            var result = 0;
            var pairs = 0;
            for (int dieValue = 1; dieValue < 7; dieValue++)
            {
                var numOfMatchingDice = dieValues.Where(v => v == dieValue).Count();
                var hasPair = numOfMatchingDice == 2;

                if(hasPair)
                    pairs++;
            }

            if (pairs == 3)
                result = 800;

            return result;
        }

        private int ScoreStraight(params int[] dieValues)
        {
            var straightSequence = new int[] { 1, 2, 3, 4, 5, 6 };

            if (straightSequence.SequenceEqual(dieValues)) return 1200;

            return 0;
        }
    }

    public class InvalidDiceQuantity : Exception
    {
        public InvalidDiceQuantity()
            : base("Please provide at least 1 and up to 6 dice values.")
        {}
    }
}

