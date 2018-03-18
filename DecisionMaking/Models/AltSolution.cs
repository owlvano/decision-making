using System.Collections.Generic;

namespace DecisionMaking.Models
{
    public class AltSolution
    {
        private CostMatrix _source;
        private int[,] _firstSolution;
        private List<List<OptimizationPoint>> _optimizationList;
        private List<int> _sigmas;

        public CostMatrix Source { get => _source; set => _source = value; }
        public int[,] FirstSolution { get => _firstSolution; set => _firstSolution = value; }
        internal List<List<OptimizationPoint>> OptimizationList { get => _optimizationList; set => _optimizationList = value; }
        public List<int> Sigmas { get => _sigmas; set => _sigmas = value; }
        

        private AltSolution()
        {
            Sigmas = new List<int>();
        }

        public AltSolution(CostMatrix source): this()
        {
            Source = source;
            FirstSolution = MathAlgorithms.NWAngle(Source.Supply, Source.Demand);

            OptimizationList = new List<List<OptimizationPoint>>();

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

        public AltSolution(AltSolution parent, int solutionIndex): this()
        {
            Source = parent.Source;
            FirstSolution = MathAlgorithms.NewFirstSolution(parent.FirstSolution, parent.OptimizationList[solutionIndex]);

            OptimizationList = new List<List<OptimizationPoint>>();

            for (int i = 0; i < FirstSolution.GetLength(0); i++)
            {
                for (int j = 0; j < FirstSolution.GetLength(1); j++)
                {
                    if (FirstSolution[i, j] != 0)
                    {
                        continue;
                    }
                    OptimizationList.Add(MathAlgorithms.FindSteppingStonePath(this, i, j));
                }
            }
        }
    }
}
