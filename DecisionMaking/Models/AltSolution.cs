namespace DecisionMaking.Models
{
    public class AltSolution
    {
        private CostMatrix _source;
        private int[,] _firstSolution;

        public CostMatrix Source { get => _source; set => _source = value; }
        public int[,] FirstSolution { get => _firstSolution; set => _firstSolution = value; }


        public AltSolution(CostMatrix source)
        {
            Source = source;
            FirstSolution = MathAlgorithms.NWAngle(Source.Supply, Source.Demand);
        }


    }
}
