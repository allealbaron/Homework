using NUnit.Framework;
using PE;

namespace TestingPE
{
    class Challenge02Should
    {
        [Test]
        public static void Test()
        {

            string input =  "Blanca,Carlos,David,Antonio,Ernesto\n" +
                            "17945,10091,10088,3907,10132\n" +
                            "2,12,13,48,11";

            string output = "Antonio,Blanca,Carlos,David,Ernesto\n" +
                            "3907,17945,10091,10088,10132\n" +
                            "48,2,12,13,11";

            Assert.AreEqual(Challenge02.SortCsvColumns(input), output);

        }

    }
}
