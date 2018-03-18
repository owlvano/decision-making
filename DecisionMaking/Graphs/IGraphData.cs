using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMaking.Graphs
{
    public interface IGraphData
    {
        string Name { get; set; }
        int Population { get; set; }
    }
}
