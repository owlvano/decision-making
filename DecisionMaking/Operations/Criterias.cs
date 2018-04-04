using DecisionMaking.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionMaking.Operations
{
    public static partial class MathOperations
    {
        #region MinMax
        public static int minMaxCriteria(List<FuzzyNumber> costsList, out string[,] output, double[] probDistr = null, double adjParam = 0)
        {
            string[] headers = new string[2] { "Eir = min(j) Eij", "Z = max(i) Eir" };
            double[,] solutionMatrix = new double[costsList.Count, headers.Length-1];
            int solutionIndex = -1;

            for (int i=0; i < costsList.Count; i++)
            {
                solutionMatrix[i,0]=costsList[i].Numbers.Min();
            }

            List<double> solutionList = Enumerable.Range(0, solutionMatrix.GetLength(0))
                    .Select(i => solutionMatrix[i, 0]).ToList();
            double max = solutionList.Max();
            solutionIndex = solutionList.IndexOf(max);

            output = GetCriteriaOutput(headers, solutionMatrix, solutionIndex);
            return solutionIndex;
        }
        #endregion
       
        #region Bayes-Laplas
        public static int BLCriteria(List<FuzzyNumber> costsList, out string[,] output, double[] probDistr, double adjParam = 0)
        {
            string[] headers = new string[2] { "Eir = Σ(j) Eij * Qj", "Z = max(i) Eir" };
            double[,] solutionMatrix = new double[costsList.Count, headers.Length-1];
            int solutionIndex = -1;
            

            for (int i = 0; i < costsList.Count; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    solutionMatrix[i, 0] += costsList[i].Numbers[j] * probDistr[j];
                }
            }

            List<double> solutionList = Enumerable.Range(0, solutionMatrix.GetLength(0))
                                .Select(i => solutionMatrix[i, 0]).ToList();
            double max = solutionList.Max();
            solutionIndex = solutionList.IndexOf(max);

            output = GetCriteriaOutput(headers, solutionMatrix, solutionIndex);
            return solutionIndex;
        }
        #endregion

        #region Savage
        public static int SavageWinCriteria(List<FuzzyNumber> costsList, out string[,] output, double[] probDistr=null, double adjParam = 0)
        {
            string[] headers = new string[5] { "A1", "A2", "A3", "Eir = max(j) Aij", "Z = min(i) Eir" };
            double[,] solutionMatrix = new double[costsList.Count, headers.Length-1];
            int solutionIndex = -1;


            for (int j = 0; j < 3; j++)
            {
                double maxRisk = Enumerable.Range(0, costsList.Count)
                                .Select(i => costsList[i].Numbers[j]).Max();

                for (int i = 0; i < costsList.Count; i++)
                {
                    solutionMatrix[i, j] = maxRisk - costsList[i].Numbers[j];
                }
            }

            for (int i = 0; i < solutionMatrix.GetLength(0); i++)
            {
                solutionMatrix[i, 3] = Enumerable.Range(0, 3)
                                .Select(j => solutionMatrix[i , j]).Max();
            }

            List<double> solutionList = Enumerable.Range(0, solutionMatrix.GetLength(0))
                    .Select(i => solutionMatrix[i, 3]).ToList();
            double min = solutionList.Min();
            solutionIndex = solutionList.IndexOf(min);

            output = GetCriteriaOutput(headers, solutionMatrix, solutionIndex);
            return solutionIndex;
        }
        #endregion

        #region Hurwitz
        public static int HurwitzCriteria(List<FuzzyNumber> costsList, out string[,] output, double[] probDistr = null, double adjParam = 0.5)
        {
            string[] headers = new string[4] { "A=C*min(j) Eij", "B=(1-C)*max(j) Eij", "Eir=A+B", "Z = max(i) Eir" };
            double[,] solutionMatrix = new double[costsList.Count, headers.Length-1];
            int solutionIndex = -1;


            for (int i = 0; i < costsList.Count; i++)
            {
                solutionMatrix[i, 0] = adjParam * costsList[i].Numbers.Min();
                solutionMatrix[i, 1] = (1 - adjParam) * costsList[i].Numbers.Max();
                solutionMatrix[i, 2] = solutionMatrix[i, 0] + solutionMatrix[i, 1];
            }

            List<double> solutionList = Enumerable.Range(0, solutionMatrix.GetLength(0))
                                .Select(i => solutionMatrix[i, 2]).ToList();
            double max = solutionList.Max();
            solutionIndex = solutionList.IndexOf(max);

            output = GetCriteriaOutput(headers, solutionMatrix, solutionIndex);
            return solutionIndex;
        }
        #endregion

        #region HL

        public static int HLCriteria(List<FuzzyNumber> costsList, out string[,] output, double[] probDistr, double adjParam)
        {
            string[] headers = new string[4] { "A = ν * Σ(j) Eij * Qj", "B = (1-ν) * min(j) Eij * Qj", "Eir=A+B", "Z = max(i) Eir" };
            double[,] solutionMatrix = new double[costsList.Count, headers.Length-1];
            int solutionIndex = -1;


            for (int i = 0; i < costsList.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    solutionMatrix[i, 0] += costsList[i].Numbers[j] * probDistr[j];
                }

                solutionMatrix[i, 0] *= adjParam;
                solutionMatrix[i, 1] = (1 - adjParam) * costsList[i].Numbers.Min();
                solutionMatrix[i, 2] = solutionMatrix[i, 0] + solutionMatrix[i, 1];
            }

            List<double> solutionList = Enumerable.Range(0, solutionMatrix.GetLength(0))
                                .Select(i => solutionMatrix[i, 2]).ToList();
            double max = solutionList.Max();
            solutionIndex = solutionList.IndexOf(max);

            output = GetCriteriaOutput(headers, solutionMatrix, solutionIndex);
            return solutionIndex;
        }
        #endregion

        #region Germeyer
        public static int GermeyerCriteria(List<FuzzyNumber> costsList, out string[,] output, double[] probDistr, double adjParam = 0)
        {

            double[,] baseMatrix = new double[costsList.Count, 3];

            for(int i =0; i< baseMatrix.GetLength(0); i++)
            {
                for(int j=0; j < baseMatrix.GetLength(1); j++)
                {
                    baseMatrix[i, j] = costsList[i].Numbers[j];
                }
            }

            double maxElement = baseMatrix.Cast<double>().Max();
            double adjustment = maxElement < 0 ? 0: -1 * (maxElement + 1);

            for (int i = 0; i < baseMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < baseMatrix.GetLength(1); j++)
                {
                    baseMatrix[i, j] += adjustment;
                }
            }

            string[] headers = new string[5] { "Ej1(+A)", "Ej2(+A)", "Ej3(+A)", "Eir = min(j) Eij * Qj", "Z = max(i) Eir" };
            double[,] solutionMatrix = new double[costsList.Count, headers.Length-1];
            int solutionIndex = -1;


            for (int i = 0; i < costsList.Count; i++)
            {
                for (int j = 0; j < baseMatrix.GetLength(1); j++)
                {
                    solutionMatrix[i, j] = baseMatrix[i, j]; 
                }
                solutionMatrix[i, 3] = Enumerable.Range(0, baseMatrix.GetLength(1))
                                .Select(a => baseMatrix[i, a]).Min();
            }

            List<double> solutionList = Enumerable.Range(0, solutionMatrix.GetLength(0))
                    .Select(i => solutionMatrix[i, 3]).ToList();
            double max = solutionList.Max();
            solutionIndex = solutionList.IndexOf(max);

            output = GetCriteriaOutput(headers, solutionMatrix, solutionIndex);
            return solutionIndex;
        }
        #endregion

        #region Multiplication
        public static int MultiplicationCriteria(List<FuzzyNumber> costsList, out string[,] output, double[] probDistr = null, double adjParam = 0)
        {
            double[,] baseMatrix = new double[costsList.Count, 3];

            for (int i = 0; i < baseMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < baseMatrix.GetLength(1); j++)
                {
                    baseMatrix[i, j] = costsList[i].Numbers[j];
                }
            }

            double minElement = baseMatrix.Cast<double>().Min();
            double adjustment = minElement > 0 ? 0 : (Math.Abs(minElement) + 1);

            for (int i = 0; i < baseMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < baseMatrix.GetLength(1); j++)
                {
                    baseMatrix[i, j] += adjustment;
                }
            }

            string[] headers = new string[5] { "Ej1(+A)", "Ej2(+A)", "Ej3(+A)", "Eir = П(j) Eij", "Z = max(i) Eir" };
            double[,] solutionMatrix = new double[costsList.Count, headers.Length-1];
            int solutionIndex = -1;


            for (int i = 0; i < costsList.Count; i++)
            {
                solutionMatrix[i, 3] = 1;
                for (int j = 0; j < baseMatrix.GetLength(1); j++)
                {
                    solutionMatrix[i, j] = baseMatrix[i, j];
                    solutionMatrix[i, 3] *= baseMatrix[i, j];
                }
            }

            List<double> solutionList = Enumerable.Range(0, solutionMatrix.GetLength(0))
                                .Select(i => solutionMatrix[i, 3]).ToList();
            double max = solutionList.Max();
            solutionIndex = solutionList.IndexOf(max);

            output = GetCriteriaOutput(headers, solutionMatrix, solutionIndex);
            return solutionIndex;
        }

        #endregion

        #region Criteria output
        public static string[,] GetCriteriaOutput(string[] headers, double[,] data, int solutionIndex)
        {
            if (headers.Length - 1 != data.GetLength(1))
            {
                return null;
            }

            string[,] output = new string[data.GetLength(0) + 1, headers.Length];

            for (int j = 0; j < output.GetLength(1); j++)
            {
                output[0, j] = headers[j];
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    output[i + 1, j] = data[i, j].ToString();
                }
            }

            output[solutionIndex+1, output.GetLength(1) - 1] = "*";
            return output;
        }
        #endregion
    }
}
