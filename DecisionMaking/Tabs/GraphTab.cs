using DecisionMaking.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
