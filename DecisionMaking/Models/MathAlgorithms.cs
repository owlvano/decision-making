using System;
using System.Collections.Generic;

namespace DecisionMaking.Models
{
    public static class MathAlgorithms
    {
        public static int[,] NWAngle(int [] supply, int[] demand)
        {
            int[,] finalRoute = new int[supply.Length, demand.Length];
            int[] tempSupply = supply;
            int[] tempDemand = demand;
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


        public static List<int[]> FindSteppingStonePath(AltSolution aSolution, int u, int v)
        {
            List<int[]> aPath = new List<int[]>();
            aPath.Add(new int[] { u, v });
            if(!LookHorizontally(aSolution, aPath, u, v, u, v))
            {
                throw new Exception("Incorrect stepping stone input");
            }
            return aPath;
        }

        public static bool LookHorizontally(AltSolution aSolution, List<int[]> aPath, int u, int v, int u1, int v1)
        {
            for(int i = 0; i < aSolution.Source.Demand.Length; i++)
            {
                if(i != v && aSolution.FirstSolution[u, i] != 0)
                {
                    if (i == v1)
                    {
                        aPath.Add(new int[] { u, i });
                        return true;
                    }
                    if(LookVertically(aSolution, aPath, u, i, u1, v1))
                    {
                        aPath.Add(new int[] { u, i });
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool LookVertically(AltSolution aSolution, List<int[]> aPath, int u, int v, int u1, int v1)
        {
            for (int i = 0; i < aSolution.Source.Supply.Length; i++)
            {
                if (i != u && aSolution.FirstSolution[i, v] != 0)
                {
                    if (LookHorizontally(aSolution, aPath, i, v, u1, v1))
                    {
                        aPath.Add(new int[] { i, v });
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
