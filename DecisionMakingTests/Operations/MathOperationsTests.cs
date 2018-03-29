using DecisionMaking.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using DecisionMaking.DataTypes;

namespace DecisionMaking.Operations.Tests
{
    [TestClass()]
    public class MathOperationsTests
    {
        [TestMethod()]
        public void minMaxCriteriaTest()
        {
            List<FuzzyNumber> costsList = new List<FuzzyNumber> { new FuzzyNumber(1, 2, 3), new FuzzyNumber(4, 5, 6), new FuzzyNumber(7, 8, 9) };
            string[] headers = null;
            int solutionIndex = -1;

            double[,] expected = new double[,] { { 1, 0 }, { 4, 0 }, { 7, 7 } };
            int expectedIndex = 2;
            //double[] probDistr = new double []{ 0.33, 0.33, 0.33 };

            double[,] actual = MathOperations.minMaxCriteria(costsList, ref headers, ref solutionIndex);

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail($"Values are not equal at [{i}, {j}]");
                    }
                }
            }
            Assert.AreEqual(expectedIndex, solutionIndex);
        }

        [TestMethod()]
        public void BLCriteriaTest()
        {
            List<FuzzyNumber> costsList = new List<FuzzyNumber> { new FuzzyNumber(1, 2, 3), new FuzzyNumber(4, 5, 6), new FuzzyNumber(7, 8, 9) };
            string[] headers = null;
            int solutionIndex = -1;

            double[,] expected = new double[,] { { 1.98, 0 }, { 4.95, 0 }, { 7.92, 7.92 } };
            int expectedIndex = 2;
            double[] probDistr = new double[] { 0.33, 0.33, 0.33 };

            double[,] actual = MathOperations.BLCriteria(costsList, ref headers, ref solutionIndex, probDistr);

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail($"Values are not equal at [{i}, {j}]");
                    }
                }
            }
            Assert.AreEqual(expectedIndex, solutionIndex);
        }

        [TestMethod()]
        public void SavageWinCriteriaTest()
        {
            List<FuzzyNumber> costsList = new List<FuzzyNumber> { new FuzzyNumber(11, 2,  7),
                                                                  new FuzzyNumber(4,  9,  3),
                                                                  new FuzzyNumber(7,  12, 5) };
            string[] headers = null;
            int solutionIndex = -1;

            double[,] expected = new double[,] { { 0, 10, 0, 10, 0 },
                                                 { 7,  3, 4,  7, 0 },
                                                 { 4,  0, 2,  4, 4 } };
            int expectedIndex = 2;

            double[,] actual = MathOperations.SavageWinCriteria(costsList, ref headers, ref solutionIndex);

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail($"Values are not equal at [{i}, {j}]");
                    }
                }
            }
            Assert.AreEqual(expectedIndex, solutionIndex);
        }

        [TestMethod()]
        public void HurwitzCriteriaTest()
        {
            List<FuzzyNumber> costsList = new List<FuzzyNumber> { new FuzzyNumber(1, 2,  3),
                                                                  new FuzzyNumber(4, 5,  6),
                                                                  new FuzzyNumber(7, 8, 9) };
            string[] headers = null;
            int solutionIndex = -1;
            double adjParam = 0.5;

            double[,] expected = new double[,] { { 0.5, 1.5, 2, 0,},
                                                 {   2,   3, 5,  0,},
                                                 { 3.5, 4.5, 8,  8 } };
            int expectedIndex = 2;

            double[,] actual = MathOperations.HurwitzCriteria(costsList, ref headers, ref solutionIndex, null, adjParam);

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail($"Values are not equal at [{i}, {j}]");
                    }
                }
            }
            Assert.AreEqual(expectedIndex, solutionIndex);
        }

        [TestMethod()]
        public void HLCriteriaTest()
        {
            List<FuzzyNumber> costsList = new List<FuzzyNumber> { new FuzzyNumber(1, 2,  3),
                                                                  new FuzzyNumber(4, 5,  6),
                                                                  new FuzzyNumber(7, 8, 9) };
            string[] headers = null;
            int solutionIndex = -1;
            double adjParam = 0.5;
            double[] probDistr = { 0.33, 0.33, 0.33 };

            double[,] expected = new double[,] { {  0.99, 0.5,  1.49,  0,},
                                                 { 2.475,   2, 4.475,  0,},
                                                 {  3.96, 3.5,  7.46,  7.46 } };
            int expectedIndex = 2;

            double[,] actual = MathOperations.HLCriteria(costsList, ref headers, ref solutionIndex, probDistr, adjParam);

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail($"Values are not equal at [{i}, {j}]");
                    }
                }
            }
            Assert.AreEqual(expectedIndex, solutionIndex);
        }

        [TestMethod()]
        public void GermeyerCriteriaTest()
        {
            List<FuzzyNumber> costsList = new List<FuzzyNumber> { new FuzzyNumber(1, 2,  3),
                                                                  new FuzzyNumber(4, 5,  6),
                                                                  new FuzzyNumber(7, 8, 9) };
            string[] headers = null;
            int solutionIndex = -1;
            double[] probDistr = { 0.33, 0.33, 0.33 };

            double[,] expected = new double[,] { { -9, -8, -7, -9, 0,},
                                                 { -6, -5, -4, -6, 0,},
                                                 { -3, -2, -1, -3, -3} };
            int expectedIndex = 2;

            double[,] actual = MathOperations.GermeyerCriteria(costsList, ref headers, ref solutionIndex, probDistr);

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail($"Values are not equal at [{i}, {j}]");
                    }
                }
            }
            Assert.AreEqual(expectedIndex, solutionIndex);
        }

        [TestMethod()]
        public void MultiplicationCriteriaTest()
        {
            List<FuzzyNumber> costsList = new List<FuzzyNumber> { new FuzzyNumber(1, 2,  3),
                                                                  new FuzzyNumber(4, 5,  6),
                                                                  new FuzzyNumber(7, 8, 9) };
            string[] headers = null;
            int solutionIndex = -1;

            double[,] expected = new double[,] { { 1, 2, 3, 6, 0,},
                                                 { 4, 5, 6, 120, 0,},
                                                 { 7, 8, 9, 504, 504} };
            int expectedIndex = 2;

            double[,] actual = MathOperations.MultiplicationCriteria(costsList, ref headers, ref solutionIndex);

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail($"Values are not equal at [{i}, {j}]");
                    }
                }
            }
            Assert.AreEqual(expectedIndex, solutionIndex);
        }
    }
}