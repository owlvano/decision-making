namespace DecisionMaking.Fuzzy
{
    public static class FuzzyOutput
    {

        public static string[,] GetFuzzyToStringMatrix(FuzzyNumber[,] fuzzyMatrix)
        {
            string[,] output = new string[fuzzyMatrix.GetLength(0), fuzzyMatrix.GetLength(1)];

            for (int i = 0; i < fuzzyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < fuzzyMatrix.GetLength(1); j++)
                {
                    output[i, j] = fuzzyMatrix[i, j].ToString();
                }
            }
            return output;
        }

        public static FuzzyNumber CalculateFuzzyCost(int[,] solution, FuzzyNumber[,] fuzzyCostMatrix)
        {
            FuzzyNumber output = new FuzzyNumber(0, 0, 0);

            if (solution.GetLength(0) != fuzzyCostMatrix.GetLength(0) || solution.GetLength(1) != fuzzyCostMatrix.GetLength(1))
            {
                return output; //lame implementation
            }

            for (int i = 0; i < solution.GetLength(0); i++)
            {
                for (int j = 0; j < solution.GetLength(1); j++)
                {
                    output += (fuzzyCostMatrix[i, j] * solution[i, j]);
                }
            }
            return output;
        }
    }
}
