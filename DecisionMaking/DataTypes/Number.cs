using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMaking.DataTypes
{
    public class Number: DataType
    {
        public int Value { get; set; }
        public Number(int number)
        {
            Value = number;
        }
  
        public override string ToString()
        {
            return Value.ToString();
        }

        protected override DataType Add(int intValue)
        {
            return this + intValue;
        }

        protected override DataType Add(DataType intValue)
        {
            return this + (Number)intValue;
        }

        protected override DataType Subtract(int intValue)
        {
            return this - intValue;
        }

        protected override DataType Multiply(int intValue)
        {
            return this * intValue;
        }


        public static Number operator +(Number NumberX, Number NumberY) => new Number(NumberX.Value + NumberY.Value);
        public static Number operator -(Number NumberX, Number NumberY) => new Number(NumberX.Value - NumberY.Value);

        public static Number operator *(Number NumberX, Number NumberY) => new Number(NumberX.Value * NumberY.Value);
        public static Number operator *(Number NumberX, int NumberY) => new Number(NumberX.Value * NumberY);

        public static implicit operator Number(int number)
        {
            Number numberObject = new Number(number);
            return numberObject;
        }
    }
}
