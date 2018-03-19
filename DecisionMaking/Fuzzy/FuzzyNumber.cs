using System;

namespace DecisionMaking.Fuzzy
{
    public class FuzzyNumber
    {
        private double[] _numbers;

        public double Left { get; set; }
        public double Middle { get; set; }
        public double Right { get; set; }

        public double this[int i]
        {
            get => _numbers[i];
            set => _numbers[i] = value;
        }

        public FuzzyNumber(double left, double middle, double right)
        {
            _numbers = new double[3] { left, middle, right };
            Left = _numbers[0];
            Middle = _numbers[1];
            Right = _numbers[2];
        }

        public override string ToString()
        {
            return string.Join(",", _numbers);
        }

        public bool CheckIntegrity()
        {
            return Left <= Middle && Middle <= Right;
        }

        public string MathModel()
        {
            return "η"  + "(x) = " + Environment.NewLine +
                "0, при x <= " + this.Left + Environment.NewLine +
                "(x - " + this.Left + ") / " + (this.Middle - this.Left) + ", при " + this.Left + " <= x <= " + this.Middle + Environment.NewLine +
                "(" + this.Right + " - x) / " + (this.Right - this.Middle) + ", при " + this.Middle + " <= x <= " + this.Right + Environment.NewLine +
                "0 при x >= " + this.Right + Environment.NewLine + Environment.NewLine +
                 " alpha = [ " + (this.Middle - this.Left) + "*α + " + this.Left + ", " + this.Right + " - " + (this.Right - this.Middle) + "*α ]";
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

        public static FuzzyNumber operator *(FuzzyNumber fuzzyNumber, int realNumber) => new FuzzyNumber(fuzzyNumber.Left * realNumber, fuzzyNumber.Middle * realNumber, fuzzyNumber.Right * realNumber);
        public static FuzzyNumber operator *(int realNumber, FuzzyNumber fuzzyNumber) => fuzzyNumber * realNumber;

        public static FuzzyNumber operator +(FuzzyNumber fuzzyNumberX, FuzzyNumber fuzzyNumberY) => new FuzzyNumber(fuzzyNumberX.Left + fuzzyNumberY.Left, fuzzyNumberX.Middle + fuzzyNumberY.Middle, fuzzyNumberX.Right + fuzzyNumberY.Right);
    }

}
