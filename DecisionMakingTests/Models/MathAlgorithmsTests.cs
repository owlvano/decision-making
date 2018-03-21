using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecisionMaking.Operations;

namespace DecisionMaking.Models.Tests
{
    [TestClass()]
    public class MathAlgorithmsTests
    {
        [TestMethod()]
        public void Should_Create_Expected_NWPath_If_Data_Is_Correct()
        {
            //arrange
            int[] supply = new int[] { 850, 800, 950 };
            int[] demand = new int[] { 550, 500, 550, 650, 350 };
            int[,] expected = new int[3, 5]             
            {
                {550, 300, 0,   0,   0},
                {0,   200, 550, 50,  0},
                {0,   0,   0,   600, 350},
            };

            //act
            int[,] actual = MathOperations.NWAngle(supply, demand);
            //assert
            for(int i = 0; i< actual.GetLength(0); i++)
            {
                for(int j = 0; j < actual.GetLength(1); j++)
                {
                    if(expected[i,j] != actual[i, j])
                    {
                        Assert.Fail($"Values are not equal at [{i}, {j}]");
                    }
                }
            }
        }
    }
}