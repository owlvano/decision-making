using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMaking.DataTypes
{
    public abstract class DataType
    {
        public abstract DataType Add(int intValue);
        public abstract DataType Add(DataType dValue);
        public abstract DataType Subtract(int intValue);
        public abstract DataType Multiply(int intValue);



        public static DataType operator +(DataType x, int y)
        {
            return x.Add(y);
        }
        public static DataType operator +(DataType x, DataType y)
        {
            return x.Add(y);
        }
        public static DataType operator -(DataType x, int y)
        {
            return x.Subtract(y);
        }
        public static DataType operator *(DataType x, int y)
        {
            return x.Multiply(y);
        }
        public static DataType operator *(int y, DataType x)
        {
            return x*y;
        }
    }
}
