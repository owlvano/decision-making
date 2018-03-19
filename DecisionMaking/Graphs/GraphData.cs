namespace DecisionMaking.Graphs
{
    public class GraphData : IGraphData
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public GraphData(string name, int population)
        {
            Name = name;
            Population = population;
        }
    }
}
