using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMaking.Models
{
    class MathModel
    {
        private CostMatrix _c_Matrix;
        private AltSolution _a_Solution;

        public CostMatrix C_Matrix { get => _c_Matrix; set => _c_Matrix = value; }
        public AltSolution A_Solution { get => _a_Solution; set => _a_Solution = value; }

        public MathModel()
        {
            C_Matrix = new CostMatrix();
        }

        public MathModel(CostMatrix matrix)
        {
            C_Matrix = matrix;
        }
    }
}
