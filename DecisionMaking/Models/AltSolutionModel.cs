using DecisionMaking.Fuzzy;
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

        private AltSolutionModel()
        {
            Sigmas = new List<int>();
            SigmaEquations = new List<string>();
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

                    PathList.Add(MathAlgorithms.FindSteppingStonePath(this, i, j));
                }
            }
        }

        public AltSolutionModel(AltSolutionModel parent, int[,] firstSolution): this(parent.Source, firstSolution)
        {
   
        }
    }
}
