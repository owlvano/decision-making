using DecisionMaking.Graphs;
using DecisionMaking.Models;
using DecisionMaking.Tabs;
using DecisionMaking.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;


namespace DecisionMaking.ViewModels
{
    class CalculationViewModel: BindableBase
    {
        private CalculationView _childView;
        private CalculationViewModel _childViewModel;

        private AltSolution _a_Solution;
        private ICollection<ITab> _tabs;
        private static int _stepCount = 0;
        private List<int> _sigmas;
        private List<string> _sigmaEquations;
        private int[,] _firstSolution;
        private int[,] _sourceCostMatrix;

        public AltSolution A_Solution { get => _a_Solution; set => _a_Solution = value; }
        public ICollection<ITab> Tabs { get => _tabs; set => _tabs = value; }
        public static int StepCount { get => _stepCount; set => _stepCount = value; }
        public List<int> Sigmas { get => _sigmas; set => _sigmas = value; }
        public List<string> SigmaEquations { get => _sigmaEquations; set => _sigmaEquations = value; }
        public int[,] FirstSolution { get => _firstSolution; set => _firstSolution = value; }
        public int[,] SourceCostMatrix { get => _sourceCostMatrix; set => _sourceCostMatrix = value; }

        public string TitleText
        {
            get => "Calculation step #" + StepCount;
        }

        public string FirstSolutionName
        {
            get => "First solution";
        }

        public DelegateCommand ClosingWindowCommand { get; set; }
        public DelegateCommand NextStepCommand { get; set; }
        

        private void ExecuteClosingWindowCommand()
        {
            StepCount--;
        }

        private void ExecuteNextStepCommand()
        {
            int minSigma = Sigmas.Min();
            if (minSigma >= 0)
            {
                MessageBox.Show("Last step (this solution is the most optimal)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            int minSigmaIndex = Sigmas.FindIndex((c) => c == minSigma);


            _childViewModel = new CalculationViewModel(new AltSolution(A_Solution, 
                                                                       MathAlgorithms.NewFirstSolution(A_Solution.FirstSolution, 
                                                                                                       A_Solution.OptimizationList[minSigmaIndex])));
            _childView = new CalculationView
            {
                DataContext = _childViewModel
            };
            
            _childView.ShowDialog();
        }

        private CalculationViewModel()
        {
            StepCount++;

            ClosingWindowCommand = new DelegateCommand(ExecuteClosingWindowCommand);
            NextStepCommand = new DelegateCommand(ExecuteNextStepCommand);

            Tabs = new ObservableCollection<ITab>();

        }

        public CalculationViewModel(AltSolution aSolution) : this()
        {
            A_Solution = aSolution;

            SourceCostMatrix = A_Solution.Source.SourceCostMatrix;
            Sigmas = A_Solution.Sigmas;
            SigmaEquations = A_Solution.SigmaEquations;
            _firstSolution = A_Solution.FirstSolution;


            for (int i = 0; i < A_Solution.OptimizationList.Count; i++)
            {
                Sigmas.Add(MathAlgorithms.CalculateSigmas(A_Solution, i, 1, out string sigmaString));
                SigmaEquations.Add(sigmaString);
                Tabs.Add(new SolutionTab(A_Solution, $"Solution {i + 2}", i, 1));
            }
            GraphCollection collection = new GraphCollection();
            foreach(SolutionTab i in Tabs)
            {
                collection.Add(new GraphData(i.Name, i.Sigma));
            }
            Tabs.Add(new GraphTab($"Sigma graph",collection));
        }
    }   
}
