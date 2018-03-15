using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMaking.Models
{
    class MathModel
    {
        private CostMatrix _c_matrix;

        public CostMatrix C_matrix { get => _c_matrix; set => _c_matrix = value; }

        public MathModel()
        {
            C_matrix = new CostMatrix();
        }

        public MathModel(CostMatrix matrix)
        {
            C_matrix = matrix;
        }
    }
}
