using System;

namespace DecisionMaking.Models
{
    public class OptimizationPoint
    {

        public int[] CurrentPoint { get; set; }
        public Func<int, int, int> OperationDelegate { get; set; }

        public int  this[int i]
        {
            get => CurrentPoint[i];
            set => CurrentPoint[i] = value;
        }

        public OptimizationPoint(int[] currentPoint)
        {
            CurrentPoint = currentPoint;
        }

    }
}
