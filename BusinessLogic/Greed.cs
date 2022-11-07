namespace BusinessLogic
{
    public class Greed
    {
        public int Score(params int[] dieValues)
        {
            if (dieValues.Length == 0 || dieValues.Length > 6) throw new InvalidDiceQuantity();

            var invalidDiceValues = dieValues.Where(v => !(Enumerable.Range(1, 6).Contains(v)));
            if (invalidDiceValues.Any()) throw new InvalidDieValue();

            if (IsStraight(dieValues)) return 1200;
            if (IsThreePairs(dieValues)) return 800;

            return CalcScores(dieValues);
        }

        private static int CalcScores(int[] dieValues)
        {
            var result = 0;
            for (int dieValue = 1; dieValue < 7; dieValue++)
            {
                var totalSameKind = dieValues.Where(v => v == dieValue).Count();
                var hasSameKindCombo = totalSameKind >= 3;

                if (hasSameKindCombo) result += CalcScoresOfSameKindCombo(dieValue, totalSameKind);
                else
                    result += GetBaseScoreOfDie(dieValue) * totalSameKind;
            }

            return result;
        }

        private static int GetBaseScoreOfDie(int dieValue)
        {
            if (dieValue == 1)
                return 100;

            if (dieValue == 5)
                return 50;

            return 0;
        }

        private static int CalcScoresOfSameKindCombo(int dieValue, int totalSameKind)
        {
            static int GetMultiplerByTotalSameKind(int totalSameKind)
            {
                switch (totalSameKind)
                {
                    case 3:
                        return 1;
                    case 4:
                        return 2;
                    case 5:
                        return 4;
                    case 6:
                        return 8;
                    default:
                        return 0;
                }
            }

            var multipler = GetMultiplerByTotalSameKind(totalSameKind);
            if (dieValue == 1)
                return 1000 * multipler;
            else
                return dieValue * 100 * multipler;
        }


        private static bool IsThreePairs(params int[] dieValues)
        {
            var pairs = 0;
            for (int dieValue = 1; dieValue < 7; dieValue++)
            {
                var numOfMatchingDice = dieValues.Where(v => v == dieValue).Count();
                var hasPair = numOfMatchingDice == 2;

                if(hasPair)
                    pairs++;
            }

            if (pairs == 3)
                return true;

            return false;
        }

        private static bool IsStraight(params int[] dieValues)
        {
            var straightSequence = new int[] { 1, 2, 3, 4, 5, 6 };

            if (straightSequence.SequenceEqual(dieValues)) return true;

            return false;
        }
        
    }

    public class InvalidDiceQuantity : Exception
    {
        public InvalidDiceQuantity()
            : base("Please provide at least 1 and up to 6 dice values.")
        {}
    }

    public class InvalidDieValue : Exception
    {
        public InvalidDieValue()
            : base("Please provide dice with value from 1 to 6.")
        {}
    }
}

