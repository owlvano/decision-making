using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMaking.DataTypes
{
    public class FuzzyNumber: DataType
    {
        private int[] _numbers;
        private const char _separator = ';';

        public int Left { get; set; }
        public int Middle { get; set; }
        public int Right { get; set; }

        public int this[int i]
        {
            get => _numbers[i];
            set => _numbers[i] = value;
        }

        public FuzzyNumber(int left, int middle, int right)
        {
            _numbers = new int[3] { left, middle, right };
            Left = _numbers[0];
            Middle = _numbers[1];
            Right = _numbers[2];
        }

        public override string ToString()
        {
            return string.Join(_separator.ToString(), _numbers);
        }

        public bool CheckIntegrity()
        {
            return Left <= Middle && Middle <= Right;
        }

        public string MathModel()
        {
            return "η" + "(x) = " + Environment.NewLine +
                "0, при x <= " + Left + Environment.NewLine +
                "(x - " + Left + ") / " + (Middle - Left) + ", при " + Left + " <= x <= " + Middle + Environment.NewLine +
                "(" + Right + " - x) / " + (Right - Middle) + ", при " + Middle + " <= x <= " + Right + Environment.NewLine +
                "0 при x >= " + Right + Environment.NewLine + Environment.NewLine +
                 " alpha = [ " + (Middle - Left) + "*α + " + Left + ", " + Right + " - " + (Right - Middle) + "*α ]";
        }

        public double MembershipFunction(double x)
        {
            if (x <= Left || x >= Right)
            {
                return 0;
            }
            else if (x >= Left && x <= Middle)
            {
                return (x - Left) / (Middle - Left);
            }
            else if (x >= Middle && x <= Right)
            {
                return (Right - x) / (Right - Middle);
            }
            else
                return 0;
        }

        protected override DataType Add(int intValue)
        {
            return this + intValue;
        }

        protected override DataType Add(DataType intValue)
        {
            return this + (FuzzyNumber)intValue;
        }
        protected override DataType Subtract(int intValue)
        {
            return this - intValue;
        }

        protected override DataType Multiply(int intValue)
        {
            return this * intValue;
        }

        public static FuzzyNumber operator +(FuzzyNumber fuzzyNumberX, FuzzyNumber fuzzyNumberY) => new FuzzyNumber(fuzzyNumberX.Left + fuzzyNumberY.Left, fuzzyNumberX.Middle + fuzzyNumberY.Middle, fuzzyNumberX.Right + fuzzyNumberY.Right);
        public static FuzzyNumber operator -(FuzzyNumber fuzzyNumberX, FuzzyNumber fuzzyNumberY) => new FuzzyNumber(fuzzyNumberX.Left - fuzzyNumberY.Right, fuzzyNumberX.Middle + fuzzyNumberY.Middle, fuzzyNumberX.Right - fuzzyNumberY.Left);
        public static FuzzyNumber operator *(FuzzyNumber fuzzyNumber, int realNumber) => new FuzzyNumber(fuzzyNumber.Left * realNumber, fuzzyNumber.Middle * realNumber, fuzzyNumber.Right * realNumber);
        public static FuzzyNumber operator *(int realNumber, FuzzyNumber fuzzyNumber) => fuzzyNumber * realNumber;
        
        public static implicit operator FuzzyNumber(int number)
        {
            FuzzyNumber fnumber = new FuzzyNumber(number, number, number);
            return fnumber;
        }


        //public static implicit operator FuzzyNumber(string numberString)
        //{

        //    FuzzyNumber fnumber = new FuzzyNumber(0, 0, 0); //evaluation TBDs
        //    return fnumber;
        //}
    }

}
