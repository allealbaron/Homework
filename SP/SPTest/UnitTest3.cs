using NUnit.Framework;
using Sp;

namespace SPTest
{
    public class Tests3
    {

        [Test]
        public void Test1()
        {

            int[] A = new int[] { 0, 4, -1, 0, 3 };
            int[] B = new int[] { 0, -2, 5, 0, 3 };

            Assert.AreEqual(Task3.Solution(A,B), 2);

            Assert.AreEqual(Task3.BestSolution(A, B), 2);

        }
    }
}