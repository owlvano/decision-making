using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
