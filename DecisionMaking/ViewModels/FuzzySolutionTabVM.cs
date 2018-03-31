using DecisionMaking.DataTypes;
using DecisionMaking.Models;
using DecisionMaking.Operations;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DecisionMaking.ViewModels
{
    class FuzzySolutionTabVM: Tabs.SolutionTab
    {
        private FuzzyNumber _firstCost;

        public FuzzyNumber CurrentCost { get; set; }
        public string FirstCostTitle { get; set; }
        public string CurrentCostTitle { get; set; }
        public int[,] ActualSolutionMatrix { get; set; }
        public Collection<FuzzyMeasurement> FuzzyMeasurements { get; private set; }
        

        public FuzzySolutionTabVM(AltSolutionModel altSolutionModel, int stepCount, int solutionCount, List<OptimizationPoint> currentPath) :base(altSolutionModel, $"E_{stepCount}_{solutionCount}")
        {
            CurrentPath = currentPath;
            ApplySteppingStoneChange(1);
            ActualSolutionMatrix = MathOperations.NewSolution(altSolutionModel.FirstSolution, CurrentPath);

            _firstCost = altSolutionModel.FirstFuzzyCost;
            CurrentCost = MathOperations.CalculateCost(ActualSolutionMatrix, altSolutionModel.Source.FuzzySourceCostMatrix);

            FirstCostTitle = $"Z_{stepCount}_1";
            CurrentCostTitle = $"Z_{stepCount}_{solutionCount}";

            FuzzyMeasurements = new Collection<FuzzyMeasurement>
            {
                new FuzzyMeasurement
                {
                    FirstX = _firstCost.Left,
                    SecondX = CurrentCost.Left,
                    ProbabilityY = 0
                },
                new FuzzyMeasurement
                {
                    FirstX = _firstCost.Middle,
                    SecondX = CurrentCost.Middle,
                    ProbabilityY = 1
                },
                new FuzzyMeasurement
                {
                    FirstX = _firstCost.Right,
                    SecondX = CurrentCost.Right,
                    ProbabilityY = 0
                },
            };
        }
    }

    class FuzzyMeasurement
    {
        public int FirstX { get; set; }
        public int SecondX { get; set; }
        public int ProbabilityY { get; set; }
    }
}
