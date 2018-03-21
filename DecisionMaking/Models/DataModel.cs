using DecisionMaking.DataTypes;

namespace DecisionMaking.Models
{
    public class DataModel
    {

        public Number[,] SourceCostMatrix { get; set; }
        internal FuzzyNumber[,] FuzzySourceCostMatrix { get; set; }
        public int[] Supply { get; set; }
        public int[] Demand { get; set; }
        public double[] ProbabilityDistribution { get; set; }

        public DataModel()
        {
            Supply = new int[] { 850, 800, 950 };
            Demand = new int[] { 550, 500, 550, 650, 350 };

            SourceCostMatrix = new Number[3, 5]
            {
                {4,1,2,7,8},
                {7,5,3,4,6},
                {8,4,6,2,5},
            };
            ProbabilityDistribution = new double[3] { 0.15, 0.8, 0.5 };
            FuzzySourceCostMatrix = new FuzzyNumber[3, 5]
            {
                { new FuzzyNumber(3,4,6), new FuzzyNumber(1,1,3), new FuzzyNumber(1,2,4),new FuzzyNumber(4,7,10),new FuzzyNumber(7,8,10),},
                { new FuzzyNumber(4,7,8), new FuzzyNumber(2,5,7), new FuzzyNumber(2,3,6),new FuzzyNumber(3,4,5),new FuzzyNumber(3,6,8),},
                { new FuzzyNumber(5,8,12), new FuzzyNumber(2,4,5), new FuzzyNumber(4,6,9),new FuzzyNumber(1,2,4),new FuzzyNumber(4,5,7),},
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

        public DataModel(Number[,] sourceCostMatrix, int[] supply, int[] demand)
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
