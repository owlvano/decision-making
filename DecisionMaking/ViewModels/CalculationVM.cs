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
using System;

namespace DecisionMaking.ViewModels
{
    class CalculationVM: BindableBase
    {
        #region Private fields

        private AltSolutionModel _altSolutionModel;
        private CalculationView _childView;
        private CalculationVM _childViewModel;

        private int _nextStepIndex;
        private int _NextStepIndex
        {
            get => _nextStepIndex;
            set => SetProperty(ref _nextStepIndex, value);
        }

        private Dictionary<CalculationMode, Action> _calculationDictionary;

        private List<int> _sigmas { get; set; }
        private List<FuzzyNumber> _fuzzyCosts { get; set; }

        #endregion

        #region Public fields

        public static int StepCount { get; set; } = 0;
        public static CalculationMode SelectedMode { get; set; } = CalculationMode.Real;

        public ICollection<ITab> Tabs { get; set; }
        public int[,] FirstSolution { get; set; }

        public DataType[,] SourceCostMatrix { get; set; }
        public FuzzyNumber[,] FuzzySourceCostMatrix { get; set; }
        public DataType FirstCost { get; set; }

        public string TitleText
        {
            get => "Calculation step #" + StepCount;
        }

        public string FirstSolutionContent
        {
            get => $"E_{StepCount}_1";
        }

        #endregion

        #region Constructors

        private CalculationVM()
        {
            StepCount++;
            _NextStepIndex = -1;

            _calculationDictionary = new Dictionary<CalculationMode, Action>() {
                { CalculationMode.Real,  RealNumberCalculation },
                { CalculationMode.Fuzzy, FuzzyNumberCalculation }
            };

            ClosingWindowCommand = new DelegateCommand(ExecuteClosingWindowCommand);
            NextStepCommand = new DelegateCommand(ExecuteNextStepCommand, CanExecuteNextStepCommand).ObservesProperty(() => _NextStepIndex);


            Tabs = new ObservableCollection<ITab>();
        }

        public CalculationVM(AltSolutionModel aSolution) : this()
        {
            _altSolutionModel = aSolution;
            FirstSolution = _altSolutionModel.FirstSolution;

            _calculationDictionary[SelectedMode]();
        }

        #endregion

        #region Commands

        public DelegateCommand ClosingWindowCommand { get; set; }
        public DelegateCommand NextStepCommand { get; set; }

        #endregion

        #region Command methods

        private void ExecuteClosingWindowCommand()
        {
            StepCount--;
        }

        private void ExecuteNextStepCommand()
        {
            _childViewModel = new CalculationVM(new AltSolutionModel(_altSolutionModel,
                                                                       MathOperations.NewSolution(_altSolutionModel.FirstSolution,
                                                                                                  _altSolutionModel.PathList[_NextStepIndex])));
            _childView = new CalculationView
            {
                DataContext = _childViewModel
            };

            _childView.ShowDialog();
        }

        private bool CanExecuteNextStepCommand()
        {
            return _NextStepIndex >= 0;
        }

        #endregion

        #region Private Methods

        private void RealNumberCalculation()
        {
            SourceCostMatrix = _altSolutionModel.Source.RealSourceCostMatrix;
            FirstCost = MathOperations.CalculateCost(FirstSolution, _altSolutionModel.Source.RealSourceCostMatrix);

            _sigmas = _altSolutionModel.Sigmas;

            for (int i = 0; i < _altSolutionModel.PathList.Count; i++)
            {
                Tabs.Add(new RealSolutionTabVM(_altSolutionModel, StepCount, i + 2, _altSolutionModel.PathList[i], 1));
            }

            GraphCollection collection = new GraphCollection();

            foreach (RealSolutionTabVM i in Tabs)
            {
                _sigmas.Add(i.Sigma);
                collection.Add(new GraphData(i.Name, i.Sigma));
            }

            Tabs.Add(new GraphTabVM($"Sigma graph", collection));

            _NextStepIndex = RealNumberNextStepIndex(_sigmas);
        }

        private void FuzzyNumberCalculation()
        {
            SourceCostMatrix = _altSolutionModel.Source.FuzzySourceCostMatrix;
            _altSolutionModel.FirstFuzzyCost = MathOperations.CalculateCost(FirstSolution, _altSolutionModel.Source.FuzzySourceCostMatrix);

            FirstCost = _altSolutionModel.FirstFuzzyCost;
            _fuzzyCosts = _altSolutionModel.FuzzyCosts;

            for (int i = 0; i < _altSolutionModel.PathList.Count; i++)
            {
                Tabs.Add(new FuzzySolutionTabVM(_altSolutionModel, StepCount, i + 2, _altSolutionModel.PathList[i]));
            }
            foreach(FuzzySolutionTabVM i in Tabs)
            {
                _fuzzyCosts.Add(i.CurrentCost);
            }
        }

        private int RealNumberNextStepIndex(List<int> sigmas)
        {
            int minSigma = sigmas.Min();
            if (minSigma >= 0)
            {
                MessageBox.Show("Last step (The following solution is the most optimal)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return -1;
            }
            return sigmas.FindIndex((c) => c == minSigma);
        }

        #endregion

    }   
}
