using DecisionMaking.DataTypes;
using DecisionMaking.Operations;
using System.Collections.Generic;

namespace DecisionMaking.Models
{
    public class AltSolutionModel
    {

        public DataModel Source { get; set; }
        public int[,] FirstSolution { get; set; }

        public List<List<OptimizationPoint>> PathList { get; set; }
        public List<int> Sigmas { get; set; }
        public List<string> SigmaEquations { get; set; }

        public List<FuzzyNumber> FuzzyCosts { get; set; }
        public FuzzyNumber FirstFuzzyCost { get; set; }

        private AltSolutionModel()
        {
            Sigmas = new List<int>();
            SigmaEquations = new List<string>();
            FuzzyCosts = new List<FuzzyNumber>();
            FirstFuzzyCost = 0;
        }

        public AltSolutionModel(DataModel source, int[,] firstSolution): this()
        {
            Source = source;
            FirstSolution = firstSolution;

            PathList = new List<List<OptimizationPoint>>();

            for (int i = 0; i < FirstSolution.GetLength(0); i++)
            {
                for(int j=0; j < FirstSolution.GetLength(1); j++)
                {

                    if ( FirstSolution[i,j] != 0)
                    {
                        continue;
                    }
                    List<OptimizationPoint> currList = MathOperations.FindSteppingStonePath(Source, FirstSolution, i, j);
                    if (currList != null)
                    {
                        PathList.Add(currList);
                    }

                }
            }
        }

        public AltSolutionModel(AltSolutionModel parent, int[,] newFirstSolution): this(parent.Source, newFirstSolution) { }
    }
}
