using DecisionMaking.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionMaking.Operations;
using Prism.Mvvm;
using Prism.Commands;

namespace DecisionMaking.ViewModels
{
    class FuzzyCriteriasTabVM : BindableBase, Tabs.ITab
    {
        private List<FuzzyNumber> _winsList;
        private List<double> _zetaData;
        private CriteriaMethod _chosenCriteria = MathOperations.minMaxCriteria;
        private CalculationVM _calcVM;
        private string[,] _calculationDataOutput;
        private bool _isAddDataEnabled = false;


        public delegate int CriteriaMethod(List<FuzzyNumber> costsList, out string[,] output, double[] probDistr, double adjParam);

        public Dictionary<string, CriteriaMethod> CriteriaDictionary { get; set; } =
            new Dictionary<string, CriteriaMethod>
        {
                {"Minmax", MathOperations.minMaxCriteria },
                {"Bayes-Laplas", MathOperations.BLCriteria },
                {"Savage(win)", MathOperations.SavageWinCriteria },
                {"Hurwitz", MathOperations.HurwitzCriteria },
                {"Hodzh-Leman", MathOperations.HLCriteria },
                {"Germeyer", MathOperations.GermeyerCriteria },
                {"Multiplication", MathOperations.MultiplicationCriteria }
        };

        public CriteriaMethod ChosenCriteria
        {
            get => _chosenCriteria;
            set
            {
                SetProperty(ref _chosenCriteria, value);
                IsAddDataEnabled = (ChosenCriteria == MathOperations.HurwitzCriteria ||
                                ChosenCriteria == MathOperations.HLCriteria) ? true : false;
            }
        }
        public bool IsAddDataEnabled
        {
            get => _isAddDataEnabled;
            set => SetProperty(ref _isAddDataEnabled, value);
        }

        public string Name { get; set; }
        public double AdjParam { get; set; } = 0.5;
        public double[] ProbDistr { get; set; }

        public string[,] WinsDataOutput { get; set; }
        public string[,] CalculationDataOutput
        {
            get => _calculationDataOutput;
            set => SetProperty(ref _calculationDataOutput, value);
        }

        public string[] ZetaOutput
        {
            get
            {
                return _zetaData.Select(x => x.ToString()).ToArray(); //yet to be displayed
            }
        }

        public DelegateCommand CalculateCommand { get; set; }
        

        public FuzzyCriteriasTabVM(string name, List<FuzzyNumber> costsList, double[] probDistr, CalculationVM calcVM)
        {
            Name = name;
            _calcVM = calcVM;
            ProbDistr = probDistr;

            _winsList = new List<FuzzyNumber>(costsList.Count);
            _zetaData = new List<double>(costsList.Count);

            foreach (FuzzyNumber i in costsList)
            {
                _winsList.Add(new FuzzyNumber(-1 * i.Left, -1 * i.Middle, -1 * i.Right));
                _zetaData.Add((i.Left + 2 * i.Middle + i.Right) / 2);
            }

            WinsDataOutput = CreateCostsDataOutput(_winsList);
            CalculationDataOutput = new string[_winsList.Count + 1, FuzzyNumber._numbersCount];

            CalculateCommand = new DelegateCommand(ExecuteCalculateCommand);
        }

        private void ExecuteCalculateCommand()
        {

            _calcVM.NextStepIndex = ChosenCriteria(_winsList, out string[,] calculationDataOutput, ProbDistr, AdjParam);
            CalculationDataOutput = calculationDataOutput;
        }

        private string[,] CreateCostsDataOutput(List<FuzzyNumber> costsList)
        {
            string[,] output = new string[costsList.Count + 1, FuzzyNumber._numbersCount];
            output[0, 0] = "F1";
            output[0, 1] = "F2";
            output[0, 2] = "F3";
            for (int i = 0; i < costsList.Count; i++)
            {
                for (int j = 0; j < FuzzyNumber._numbersCount; j++)
                {
                    output[i + 1, j] = costsList[i][j].ToString();
                }
            }
            return output;
        }

    }
}
