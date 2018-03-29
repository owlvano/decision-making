using DecisionMaking.Constants;
using DecisionMaking.Graphs;
using DecisionMaking.Models;
using DecisionMaking.Operations;
using DecisionMaking.Tabs;
using DecisionMaking.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DecisionMaking.DataTypes;

namespace DecisionMaking.ViewModels
{
    class CalculationViewModel: BindableBase
    {
        private AltSolutionModel _altSolutionModel;
        private CalculationView _childView;
        private CalculationViewModel _childViewModel;

        public static int StepCount { get; set; } = 0;
        public static CalculationMode SelectedMode { get; set; } = CalculationMode.Real;


        public ICollection<ITab> Tabs { get; set; }
        public int[,] FirstSolution { get; set; }
        public int[] Supply { get; set; }
        public int[] Demand { get; set; }

        public Number[,] SourceCostMatrix { get; set; }
        public FuzzyNumber[,] FuzzySourceCostMatrix { get; set; }
        public DataType FirstCost { get; set; }

        public List<FuzzyNumber> FuzzyCosts { get; set; }

        public List<int> Sigmas { get; set; }
        public List<string> SigmaEquations { get; set; }


        public string TitleText
        {
            get => "Calculation step #" + StepCount;
        }

        public string FirstSolutionContent
        {
            get => $"E_{StepCount}_1";
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


            _childViewModel = new CalculationViewModel(new AltSolutionModel(_altSolutionModel, 
                                                                       MathOperations.NewSolution(_altSolutionModel.FirstSolution, 
                                                                                                       _altSolutionModel.PathList[minSigmaIndex])));
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

        public CalculationViewModel(AltSolutionModel aSolution) : this()
        {
            _altSolutionModel = aSolution;

            SourceCostMatrix = _altSolutionModel.Source.SourceCostMatrix;
            FirstSolution = _altSolutionModel.FirstSolution;
            Supply = _altSolutionModel.Source.Supply;
            Demand = _altSolutionModel.Source.Demand;


            FirstCost = MathOperations.CalculateCost(FirstSolution, SourceCostMatrix);

            Sigmas = _altSolutionModel.Sigmas;
            SigmaEquations = _altSolutionModel.SigmaEquations;

            for (int i = 0; i < _altSolutionModel.PathList.Count; i++)
            {
                Sigmas.Add(MathOperations.CalculateSigma(_altSolutionModel, i, 1, out string sigmaString));
                SigmaEquations.Add(sigmaString);
                Tabs.Add(new SolutionTab(_altSolutionModel, $"E_{StepCount}_{i + 2}", i, 1));
            }

            GraphCollection collection = new GraphCollection();
            foreach (SolutionTab i in Tabs)
            {
                collection.Add(new GraphData(i.Name, i.Sigma));
            }

            Tabs.Add(new GraphTab($"Sigma graph", collection));
        }
    }   
}
