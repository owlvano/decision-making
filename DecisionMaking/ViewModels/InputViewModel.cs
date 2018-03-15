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


namespace DecisionMaking.ViewModels
{
    public class InputViewModel
    {
        private MathModel _model;

        public int[,] CostMatrixSource { get; set; }
        public int[] Supply { get; set; }
        public int[] Demand { get; set; }

        public InputViewModel()
        {
            _model = new MathModel();

            CostMatrixSource = _model.C_matrix.SourceCostMatrix;
            Supply = _model.C_matrix.Supply;
            Demand = _model.C_matrix.Demand;
        }
    }
}
