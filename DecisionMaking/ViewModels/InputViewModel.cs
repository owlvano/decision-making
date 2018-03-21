using System.Windows;
using DecisionMaking.Models;
using DecisionMaking.Views;
using Prism.Mvvm;
using Prism.Commands;
using DecisionMaking.Constants;
using DecisionMaking.Operations;
using DecisionMaking.DataTypes;

namespace DecisionMaking.ViewModels
{
    public class InputViewModel: BindableBase
    {
        private DataModel _dataModel;
        private CalculationViewModel _childViewModel;
        private CalculationView _childView;

        private CalculationMode _selectedMode;
        private DataType[,] _sourceCostMatrix;
        private int[] _supply;
        private int[] _demand;

        public CalculationMode SelectedMode
        {
            get => _selectedMode;
            set => SetProperty(ref _selectedMode, value);
        }

        public DataType[,] SourceCostMatrix
        {
            get => _sourceCostMatrix;
            set => SetProperty(ref _sourceCostMatrix, value);
        }
        
        public int[] Supply
        {
            get => _supply;
            set => SetProperty(ref _supply, value);
        }

        public int[] Demand
        {
            get => _demand;
            set => SetProperty(ref _demand, value);
        }

        public string[,] FuzzyToStringMatrix { get; set; }

        public DelegateCommand<int?> ChangeModeCommand { get; set; }
        public DelegateCommand CalculateCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        public InputViewModel()
        {
            _dataModel = new DataModel();
            SelectedMode = CalculationMode.NonFuzzy;

            SourceCostMatrix = _dataModel.SourceCostMatrix;
            Supply = _dataModel.Supply;
            Demand = _dataModel.Demand;
            FuzzyToStringMatrix = FuzzyOperations.GetFuzzyToStringMatrix(_dataModel.FuzzySourceCostMatrix);

            ChangeModeCommand = new DelegateCommand<int?>(ExecuteChangeModeCommand);
            CalculateCommand = new DelegateCommand(ExecuteCalculateCommand, CanExecuteCalculateCommand).
                                   ObservesProperty(() => Supply).
                                   ObservesProperty(() => Demand).
                                   ObservesProperty(() => SourceCostMatrix);
            ExitCommand = new DelegateCommand(ExecuteExitCommand);


        }

        private void ExecuteChangeModeCommand(int? selectedIndex)
        {
            if(selectedIndex != null)
            {
                SelectedMode = (CalculationMode)selectedIndex; //to be refactored
            }
        }
        private bool CanExecuteCalculateCommand()
        {
            //to be implemented
            return true;
        }
        private void ExecuteCalculateCommand()
        {
            CalculationViewModel.SelectedMode = SelectedMode;
            _childViewModel = new CalculationViewModel(new AltSolutionModel(_dataModel, MathOperations.NWAngle(_dataModel.Supply, _dataModel.Demand)));
            _childView = new CalculationView();
            _childView.DataContext = _childViewModel;
            _childView.ShowDialog();
        }


        private void ExecuteExitCommand() => Application.Current.Shutdown();

        
    }


}
