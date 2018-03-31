using DecisionMaking.Graphs;


namespace DecisionMaking.ViewModels
{
    class GraphTabVM : Tabs.ITab
    {
        public string Name { get; set; }
        public GraphCollection SeriesCollection { get; set; }

        public GraphTabVM(string name, GraphCollection collection)
        {
            Name = name;
            SeriesCollection = collection;
        }
    }
}
