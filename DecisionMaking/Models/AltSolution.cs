using System.Collections.Generic;

namespace DecisionMaking.Models
{
    public class AltSolution
    {
        private CostMatrix _source;
        private int[,] _firstSolution;
        private List<List<int[]>> _optimizationList;

        public CostMatrix Source { get => _source; set => _source = value; }
        public int[,] FirstSolution { get => _firstSolution; set => _firstSolution = value; }
        public List<List<int[]>> OptimizationList { get => _optimizationList; set => _optimizationList = value; }

        public AltSolution(CostMatrix source)
        {
            Source = source;
            FirstSolution = MathAlgorithms.NWAngle(Source.Supply, Source.Demand);
            OptimizationList = new List<List<int[]>>();

            for (int i = 0; i < FirstSolution.GetLength(0); i++)
            {
                for(int j=0; j < FirstSolution.GetLength(1); j++)
                {
                    if ( FirstSolution[i,j] != 0)
                    {
                        continue;
                    }
                    OptimizationList.Add(MathAlgorithms.FindSteppingStonePath(this, i, j));
                }
            }
        }


    }
}
