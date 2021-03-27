using NUnit.Framework;
using PE;

namespace TestingPE
{
    class Challenge01Should
    {
        [Test]
        public static void One()
        {

            Assert.AreEqual(Challenge01.LookSay(1), 11);

        }

        [Test]
        public static void Eleven()
        {

            Assert.AreEqual(Challenge01.LookSay(11), 21);

        }


        [Test]
        public static void Zero()
        {

            Assert.AreEqual(Challenge01.LookSay(0), 10);

        }

        [Test]
        public static void Number1234()
        {

            Assert.AreEqual(Challenge01.LookSay(1234), 11121314);

        }

    }
}
