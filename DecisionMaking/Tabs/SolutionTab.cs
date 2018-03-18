using DecisionMaking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMaking.Tabs
{
    public class SolutionTab: ITab
    {
        private AltSolution _a_Solution;
        private List<OptimizationPoint> _currentOptimizationPath;
        private string[,] _solutionMatrixOutput;
        private int _sigma;

        public AltSolution A_Solution { get => _a_Solution; set => _a_Solution = value; }
        public List<OptimizationPoint> CurrentOptimizationPath { get => _currentOptimizationPath; set => _currentOptimizationPath = value; }
        public string[,] SolutionMatrixOutput { get => _solutionMatrixOutput; set => _solutionMatrixOutput = value; }
        public int Sigma { get => _sigma; set => _sigma = value; }
        public string Name { get; set; }

        public SolutionTab(AltSolution altSolution, string name)
        {
            Name = name;
            A_Solution = altSolution;
            SolutionMatrixOutput = FillOutputMatrix(A_Solution.FirstSolution);
            Sigma = 0;
        }

        public SolutionTab(AltSolution altSolution, string name, int solutionNum, int amount): this(altSolution, name)
        {
            CurrentOptimizationPath = A_Solution.OptimizationList[solutionNum];
            Sigma = A_Solution.Sigmas[solutionNum];
            ApplySteppingStoneChange(amount);
        }

        public void ApplySteppingStoneChange(int amount)
        {
            for (int i = 0; i < CurrentOptimizationPath.Count; i++)
            {
                SolutionMatrixOutput[CurrentOptimizationPath[i][0], CurrentOptimizationPath[i][1]] += (i % 2 == 0 ? " +" : " -") + amount;
            }
        }

        public string[,] FillOutputMatrix(int[,] source)
        {
            string[,]  output = new string[source.GetLength(0), source.GetLength(1)];
            for (int i = 0; i < source.GetLength(0); i++)
            {
                for(int j=0; j< source.GetLength(1); j++)
                {
                    output[i, j] = source[i, j].ToString();
                }
            }
            return output;
        }
    }
}
