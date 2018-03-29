using DecisionMaking.DataTypes;
using DecisionMaking.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionMaking.Operations
{
    public static partial class MathOperations
    {

        #region North-Western Angle

        public static int[,] NWAngle(int[] supply, int[] demand)
        {
            int[,] finalRoute = new int[supply.Length, demand.Length];

            int[] tempSupply = new int[supply.Length];
            int[] tempDemand = new int[demand.Length];

            Array.Copy(supply, tempSupply, supply.Length);
            Array.Copy(demand, tempDemand, demand.Length);

            int minValue;
            for (int i = 0; i < finalRoute.GetLength(0); i++)
            {
                for (int j = 0; j < finalRoute.GetLength(1); j++)
                {
                    if (tempDemand[j] == 0)
                    {
                        continue;
                    }
                    minValue = Math.Min(tempSupply[i], tempDemand[j]);
                    finalRoute[i, j] = minValue;
                    tempSupply[i] -= minValue;
                    tempDemand[j] -= minValue;

                    if (tempSupply[i] == 0)
                    {
                        break;
                    }
                }
            }
            return finalRoute;
        }

        #endregion

        #region Stepping Stone algorithm

        public static List<OptimizationPoint> FindSteppingStonePath(DataModel dataModel, int[,] originalSolution, int u, int v)
        {
            ;
            List<OptimizationPoint> aPath = new List<OptimizationPoint>();
            aPath.Add(new OptimizationPoint(new int[] { u, v }));

            if (!LookHorizontally(dataModel, originalSolution, aPath, u, v, u, v))
            {
                //to be refactored
                throw new Exception("Incorrect stepping stone input");
            }

            for (int i = 0; i < aPath.Count; i++)
            {
                if (i % 2 == 0)
                {
                    aPath[i].OperationDelegate = Addition;
                }
                else
                {
                    aPath[i].OperationDelegate = Subtraction;
                }
            }

            return aPath;
        }

        public static bool LookHorizontally(DataModel dataModel, int[,] originalSolution, List<OptimizationPoint> aPath, int u, int v, int u1, int v1)
        {
            for (int i = 0; i < dataModel.Demand.Length; i++)
            {
                if (i != v && originalSolution[u, i] != 0)
                {
                    if (i == v1)
                    {
                        aPath.Add(new OptimizationPoint(new int[] { u, i }));
                        return true;
                    }
                    if (LookVertically(dataModel, originalSolution, aPath, u, i, u1, v1))
                    {
                        aPath.Add(new OptimizationPoint(new int[] { u, i }));
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool LookVertically(DataModel dataModel, int[,] originalSolution, List<OptimizationPoint> aPath, int u, int v, int u1, int v1)
        {
            for (int i = 0; i < dataModel.Supply.Length; i++)
            {
                if (i != u && originalSolution[i, v] != 0)
                {
                    if (LookHorizontally(dataModel, originalSolution, aPath, i, v, u1, v1))
                    {
                        aPath.Add(new OptimizationPoint(new int[] { i, v }));
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Calculate sigma
        public static int CalculateSigma(AltSolutionModel aSolution, int solutionNum, int amount, out string equation)
        {
            int sigma = 0;
            equation = "0";

            List<OptimizationPoint> CurrentOptimizationPath = aSolution.PathList[solutionNum];

            for (int i = 0; i < CurrentOptimizationPath.Count; i++)
            {
                sigma = CurrentOptimizationPath[i].OperationDelegate(sigma, amount * aSolution.Source.SourceCostMatrix[CurrentOptimizationPath[i][0], CurrentOptimizationPath[i][1]].Value);
                equation += ((CurrentOptimizationPath[i].OperationDelegate == Addition) ? "+" : "-") + aSolution.Source.SourceCostMatrix[CurrentOptimizationPath[i][0], CurrentOptimizationPath[i][1]].ToString();
            }
            equation += "=";

            return sigma;
        }

        #endregion

        #region CalculateCost
        public static T CalculateCost<T>(int[,] solution, T[,] costMatrix) where T : DataType
        {
            T output = Activator.CreateInstance<T>();

            if (solution.GetLength(0) != costMatrix.GetLength(0) || solution.GetLength(1) != costMatrix.GetLength(1))
            {
                return output; //lame implementation
            }
            for (int i = 0; i < solution.GetLength(0); i++)
            {
                for (int j = 0; j < solution.GetLength(1); j++)
                {
                    output = (T)output.Add((T)costMatrix[i, j].Multiply(solution[i, j]));
                }
            }
            return output;
        }



        #endregion

        #region Adjust new solution based on the previous one
        public static int[,] NewSolution(int[,] originalSolution, List<OptimizationPoint> adjustmentList)
        {
            int[,] finalRoute = originalSolution.Clone() as int[,];
            List<int> subtrList = new List<int>();
            foreach (OptimizationPoint i in adjustmentList)
            {
                if (i.OperationDelegate == Subtraction)
                {
                    subtrList.Add(originalSolution[i[0], i[1]]);
                }
            }
            int adjustmentAmount = subtrList.Min();
            foreach (OptimizationPoint i in adjustmentList)
            {
                finalRoute[i[0], i[1]] = i.OperationDelegate(finalRoute[i[0], i[1]], adjustmentAmount);
            }
            return finalRoute;
        }
        #endregion

        #region Stepping stone elements' operations
        public static int Addition(int x, int y)
        {
            return x + y;
        }

        public static int Subtraction(int x, int y)
        {
            return x - y;
        }
        #endregion
    }

}
