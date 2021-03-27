using NUnit.Framework;
using PE;

namespace TestingPE
{
    class Challenge04Should
    {
        [Test]
        public static void ReduceToOeste()
        {

            string[] input = { "NORTE", "SUR", "SUR", "ESTE", "OESTE", "NORTE", "OESTE" };

            string[] output = { "OESTE" };

            Assert.AreEqual(DirReduction.DirReduc(input), output);

        }

        [Test]
        public static void ReduceToNothing()
        {

            string[] input = { "NORTE","SUR","SUR","ESTE","OESTE","NORTE" };

            string[] output = {  };

            Assert.AreEqual(DirReduction.DirReduc(input), output);

        }

        [Test]
        public static void NotReduce()
        {

            string[] input = { "NORTE", "OESTE", "SUR", "ESTE" };

            Assert.AreEqual(DirReduction.DirReduc(input), input);

        }

    }
}
