using DecisionMaking.Graphs;

namespace DecisionMaking.Tabs
{
    public class GraphTab : ITab
    {
        public string Name { get; set; }
        public GraphCollection SeriesCollection { get; set; }

        public GraphTab(string name, GraphCollection collection)
        {
            Name = name;
            SeriesCollection = collection;
        }
    }
    

}
