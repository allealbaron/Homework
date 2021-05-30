using NUnit.Framework;
using Sp;

namespace SPTest
{
    public class Tests2
    {

        [Test]
        public void Test1()
        {
            int[] A = new int[] {1,1,1 };

            Assert.AreEqual(Task2.Solution(A), 3);

        }

        [Test]
        public void Test2()
        {
            int[] A = new int[] { 1, 2, 3 };

            Assert.AreEqual(Task2.Solution(A), 0);

        }

        [Test]
        public void Test3()
        {
            int[] A = new int[] { 1, 2, 3, 4, 4, 6 };

            Assert.AreEqual(Task2.Solution(A), 1);

        }

        [Test]
        public void Test4()
        {
            int[] A = new int[] { 1, 2, 2, 4, 4, 6 };

            Assert.AreEqual(Task2.Solution(A), 2);

        }

    }
}