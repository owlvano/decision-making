using DecisionMaking.Models;
using DecisionMaking.Operations;
using System.Collections.Generic;

namespace DecisionMaking.ViewModels
{
    class RealSolutionTabVM: Tabs.SolutionTab
    {
        public int Sigma { get; set; }
        public string SigmaEquation { get; set; }

        public RealSolutionTabVM(AltSolutionModel altSolutionModel, int stepCount, int solutionCount, List<OptimizationPoint> currentPath, int amount): base(altSolutionModel, $"E_{stepCount}_{solutionCount}")
        {
            CurrentPath = currentPath;

            Sigma = MathOperations.CalculateSigma(altSolutionModel, CurrentPath, 1, out string tempSigmaEquation);
            SigmaEquation = tempSigmaEquation;

            ApplySteppingStoneChange(amount);
        }
    }
}
