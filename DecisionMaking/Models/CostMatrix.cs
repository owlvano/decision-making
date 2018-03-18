using System;

namespace DecisionMaking.Models
{
    public class CostMatrix
    {
        private int[,] _sourceCostMatrix;
        private int[] _supply;
        private int[] _demand;

        public int[,] SourceCostMatrix { get => _sourceCostMatrix; set => _sourceCostMatrix = value; }
        public int[] Supply { get => _supply; set => _supply = value; }
        public int[] Demand { get => _demand; set => _demand = value; }

        public CostMatrix()
        {
            Supply = new int[] { 850, 800, 950 };
            Demand = new int[] { 550, 500, 550, 650, 350 };
            SourceCostMatrix = new int[3, 5]
            {
                {4,1,2,7,8},
                {7,5,3,4,6},
                {8,4,6,2,5},
            };

            //Костины данные
            //Supply = new int[] { 900, 800, 580, 620 };   
            //Demand = new int[] { 550, 500, 550, 650, 350 };

            //Supply = new int[] { 120, 140, 115, 105 };
            //Demand = new int[] { 75, 65, 90, 95, 100, 55 };
            //SourceCostMatrix = new int[4, 6]
            //{
            //    {4,1,2,7,8,5},
            //    {7,5,3,4,6,8},
            //    {9,8,5,6,11,12},
            //    {8,4,6,2,5,10},
            //};
        }

        public CostMatrix(int[,] sourceCostMatrix, int[] supply, int[] demand)
        {
            Supply = supply;
            Demand = demand;
            SourceCostMatrix = sourceCostMatrix;
        }

        //public bool ValidateData(out string message)
        //{
        //    if(Supply.Length != SourceCostMatrix.GetLength(0))
        //    {
        //        message = "Supplies don't match matrix";
        //        return false;
        //    }
        //    else if (Demand.Length != SourceCostMatrix.GetLength(1))
        //    {
        //        message = "Demands don't match matrix";
        //        return false;
        //    }
        //    else
        //    {
        //        message = "Seems to be alright";
        //        return true;
        //    }
        //}
    }
}
