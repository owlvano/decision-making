using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionMaking.Models
{
    public static class MathAlgorithms
    {

        #region North-Western Angle

        public static int[,] NWAngle(int [] supply, int[] demand)
        {
            int[,] finalRoute = new int[supply.Length, demand.Length];

            int[] tempSupply= new int[supply.Length]; 
            int[] tempDemand = new int[demand.Length];

            Array.Copy(supply, tempSupply, supply.Length);
            Array.Copy(demand, tempDemand, demand.Length);

            int minValue;
            for(int i=0; i < finalRoute.GetLength(0); i++)
            {
                for (int j = 0; j < finalRoute.GetLength(1); j++)
                {
                    if(tempDemand[j] == 0)
                    {
                        continue;
                    }
                    minValue = Math.Min(tempSupply[i], tempDemand[j]);
                    finalRoute[i,j] = minValue;
                    tempSupply[i] -= minValue;
                    tempDemand[j] -= minValue;

                    if(tempSupply[i] == 0)
                    {
                        break;
                    }
                }
            }
            return finalRoute;
        }

        #endregion

        #region Stepping Stone algorithm

        public static List<OptimizationPoint> FindSteppingStonePath(AltSolution aSolution, int u, int v)
        {;
            List<OptimizationPoint> aPath = new List<OptimizationPoint>();
            aPath.Add(new OptimizationPoint(new int[] { u, v }));

            if(!LookHorizontally(aSolution, aPath, u, v, u, v))
            {
                //to be refactored
                throw new Exception("Incorrect stepping stone input");
            }

            for(int i=0; i < aPath.Count; i++)
            {
                if (i%2 == 0)
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

        public static bool LookHorizontally(AltSolution aSolution, List<OptimizationPoint> aPath, int u, int v, int u1, int v1)
        {
            for(int i = 0; i < aSolution.Source.Demand.Length; i++)
            {
                if(i != v && aSolution.FirstSolution[u, i] != 0)
                {
                    if (i == v1)
                    {
                        aPath.Add(new OptimizationPoint(new int[] { u, i }));
                        return true;
                    }
                    if(LookVertically(aSolution, aPath, u, i, u1, v1))
                    {
                        aPath.Add(new OptimizationPoint(new int[] { u, i }));
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool LookVertically(AltSolution aSolution, List<OptimizationPoint> aPath, int u, int v, int u1, int v1)
        {
            for (int i = 0; i < aSolution.Source.Supply.Length; i++)
            {
                if (i != u && aSolution.FirstSolution[i, v] != 0)
                {
                    if (LookHorizontally(aSolution, aPath, i, v, u1, v1))
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
        public static int CalculateSigmas(AltSolution aSolution, int solutionNum, int amount)
        {
            int sigma = 0;

            List<OptimizationPoint> CurrentOptimizationPath = aSolution.OptimizationList[solutionNum];

            for (int i = 0; i < CurrentOptimizationPath.Count; i++)
            {
                sigma = CurrentOptimizationPath[i].OperationDelegate(sigma, amount * aSolution.Source.SourceCostMatrix[CurrentOptimizationPath[i][0], CurrentOptimizationPath[i][1]]);

            }

            return sigma;
        }

        #endregion

        public static int[,] NewFirstSolution(int[,] originalSolution, List<OptimizationPoint> adjustmentList)
        {
            int[,] finalRoute = originalSolution.Clone() as int[,];
            List<int> subtrList = new List<int>();
            foreach(OptimizationPoint i in adjustmentList)
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

        public static int Addition(int x, int y)
        {
            return x + y;
        }

        public static int Subtraction(int x, int y)
        {
            return x - y;
        }
    }

}
