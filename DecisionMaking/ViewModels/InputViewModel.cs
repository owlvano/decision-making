using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using DecisionMaking.Models;
using DecisionMaking.Views;
using Prism.Mvvm;
using System.Windows.Input;
using Prism.Commands;

namespace DecisionMaking.ViewModels
{
    public class InputViewModel: BindableBase
    {
        private MathModel _model;
        private CalculationViewModel _childViewModel;
        private CalculationView _childView;
        private int[,] _costMatrixSource;
        private int[] _supply;
        private int[] _demand;

        public int[,] CostMatrixSource
        {
            get => _costMatrixSource;

            set
            {
                SetProperty(ref _costMatrixSource, value);
            }
        }
        public int[] Supply
        {
            get => _supply;

            set
            {
                SetProperty(ref _supply, value);
            }
        }
        public int[] Demand
        {
            get => _demand;

            set
            {
                SetProperty(ref _demand, value);
            }
        }

        public InputViewModel()
        {
            _model = new MathModel();

            CostMatrixSource = _model.C_Matrix.SourceCostMatrix;
            Supply = _model.C_Matrix.Supply;
            Demand = _model.C_Matrix.Demand;

            CalculateCommand = new DelegateCommand(ExecuteCalculateCommand, CanExecuteCalculateCommand).
                                   ObservesProperty(() => Supply).
                                   ObservesProperty(() => Demand).
                                   ObservesProperty(() => CostMatrixSource);
            ExitCommand = new DelegateCommand(ExecuteExitCommand);


        }

        public DelegateCommand CalculateCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        private bool CanExecuteCalculateCommand()
        {
            //to be implemented
            return true;
        }
        private void ExecuteCalculateCommand()
        {
            _childViewModel = new CalculationViewModel(new AltSolution(_model.C_Matrix, 
                                                           MathAlgorithms.NWAngle(_model.C_Matrix.Supply, 
                                                                                  _model.C_Matrix.Demand)));
            _childView = new CalculationView();
            _childView.DataContext = _childViewModel;
            _childView.ShowDialog();
        }

        private void ExecuteExitCommand() => Application.Current.Shutdown();

    }
}
