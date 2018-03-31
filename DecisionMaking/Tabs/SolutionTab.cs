using DecisionMaking.Models;
using DecisionMaking.Operations;
using System.Collections.Generic;

namespace DecisionMaking.Tabs
{
    public abstract class SolutionTab: ITab
    {
        public string Name { get; set; }
        public string[,] SolutionMatrixOutput { get; set; }
        public List<OptimizationPoint> CurrentPath { get; set; }

        public SolutionTab(AltSolutionModel altSolutionModel, string name)
        {
            Name = name;
            SolutionMatrixOutput = FillOutputMatrix(altSolutionModel.FirstSolution);

        }

        public void ApplySteppingStoneChange(int amount)
        {
            for (int i = 0; i < CurrentPath.Count; i++)
            {
                SolutionMatrixOutput[CurrentPath[i][0], CurrentPath[i][1]] += (i % 2 == 0 ? " +" : " -") + amount;
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
