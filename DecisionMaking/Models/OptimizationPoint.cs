using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMaking.Models
{
    public class OptimizationPoint
    {
        private int[] _currentPoint;
        private Func<int, int, int> operation;

        public int[] CurrentPoint { get => _currentPoint; set => _currentPoint = value; }
        public Func<int, int, int> OperationDelegate { get => operation; set => operation = value; }

        public int  this[int i]
        {
            get { return CurrentPoint[i]; }
            set { CurrentPoint[i] = value; }
        }

        public OptimizationPoint(int[] currentPoint)
        {
            CurrentPoint = currentPoint;
        }

    }
}
