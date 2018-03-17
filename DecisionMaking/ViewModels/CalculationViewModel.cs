using DecisionMaking.Models;
using DecisionMaking.Tabs;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DecisionMaking.ViewModels
{
    class CalculationViewModel: BindableBase
    {
        private MathModel _model;

        private ICollection<ITab> _tabs;
        public ICollection<ITab> Tabs { get => _tabs; set => _tabs = value; }

        private static int _stepCount = 0;
        public static int StepCount { get => _stepCount; set => _stepCount = value; }

        public string TitleText
        {
            get => "Calculation step";
        }



        private int[,] _firstSolution;
        public int[,] FirstSolution
        {
            get => _firstSolution;
            set
            {
                SetProperty(ref _firstSolution, value);
            }
        }


        public CalculationViewModel()
        {
            StepCount++;
            CloseWindowCommand = new DelegateCommand(ExecuteCloseWindowCommand);
            Tabs = new ObservableCollection<ITab>();
        }

        public CalculationViewModel(MathModel model) : this()
        {
            _model = model;
            _model.A_solution = new AltSolution(_model.C_matrix);
            _firstSolution = _model.A_solution.FirstSolution;
            Tabs.Add(new SolutionTab(_model.A_solution, "First Solution"));
            for (int i = 0; i < _model.A_solution.OptimizationList.Count; i++)
            {
                Tabs.Add(new SolutionTab(_model.A_solution, $"Solution {i+2}", i));
            }

        }

        public DelegateCommand CloseWindowCommand { get; set; }

        private void ExecuteCloseWindowCommand()
        {
            StepCount--;
        }
    }
}
