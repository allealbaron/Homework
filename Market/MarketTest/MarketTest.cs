using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketSigndownTestProject
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MarketSigndownTest
    {
        Market.Market market;
        public MarketSigndownTest()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public void TestMarketSigndown_01_Empty()
        {
            market = new Market.Market();
            List<Market.MarketElement> MarketElements = new List<Market.MarketElement>();
            market.MarketSigndown(0, MarketElements);


            Assert.IsTrue(MarketElements.Count == 0, "Returned MarketElements list is empty when imput list is empty too.");
        }

        public void TestMarketSigndown_02_Simple_Example_NoMins1()
        {

            // test the trivial case.
            market = new Market.Market();
            List<Market.MarketElement> listUWs = new List<Market.MarketElement>
            {
                new Market.MarketElement(10, "Element 1", 40, 30, 0),
                new Market.MarketElement(20, "Element 2", 60, 20, 0)
            };

            listUWs = market.MarketSigndown(100, listUWs);

            AssertSignedLine(listUWs, "Element 1", 40f);
            AssertSignedLine(listUWs, "Element 2", 60f);
        }

        public void TestMarketSigndown_03_Simple_Example_NoMins_TotalOrderNot100()
        {

            // 
            market = new Market.Market();
            List<Market.MarketElement> listUWs = new List<Market.MarketElement>
            {
                new Market.MarketElement(10, "Element 1", 30, 0, 0),
                new Market.MarketElement(20, "Element 2", 30, 0, 0)
            };

            listUWs = market.MarketSigndown(60, listUWs);

            AssertSignedLine(listUWs, "Element 1", 30f);
            AssertSignedLine(listUWs, "Element 2", 30f);
        }

        public void TestMarketSigndown_04_Simple_Example_NoMins2()
        {

            // test the trivial case.
            market = new Market.Market();
            List<Market.MarketElement> listUWs = new List<Market.MarketElement>
            {
                new Market.MarketElement(10, "Element 1", 80, 10, 0),
                new Market.MarketElement(20, "Element 2", 40, 10, 0),
                new Market.MarketElement(30, "Element 3", 40, 20, 0)
            };

            listUWs = market.MarketSigndown(100, listUWs);

            AssertSignedLine(listUWs, "Element 1", 50f);
            AssertSignedLine(listUWs, "Element 2", 25f);
            AssertSignedLine(listUWs, "Element 3", 25f);
        }

        public void TestMarketSigndown_05_Simple_Example_NoMins3()
        {

            // test the trivial case.
            market = new Market.Market();
            List<Market.MarketElement> listUWs = new List<Market.MarketElement>
            {
                new Market.MarketElement(10, "Element 1", 80, 0, 0),
                new Market.MarketElement(20, "Element 2", 40, 0, 0),
                new Market.MarketElement(30, "Element 3", 40, 0, 0)
            };

            listUWs = market.MarketSigndown(50, listUWs);

            AssertSignedLine(listUWs, "Element 1", 25f);
            AssertSignedLine(listUWs, "Element 2", 12.5f);
            AssertSignedLine(listUWs, "Element 3", 12.5f);
        }

        public void TestMarketSigndown_06_Mins1_AsPerExcel_Example()
        {

            // test the trivial case.
            market = new Market.Market();
            List<Market.MarketElement> listUWs = new List<Market.MarketElement>
            {
                new Market.MarketElement(10, "Element 1", 80, 10, 0),
                new Market.MarketElement(20, "Element 2", 90, 10, 0),
                new Market.MarketElement(30, "Element 3", 40, 20, 0)
            };

            listUWs = market.MarketSigndown(100, listUWs);

            AssertSignedLine(listUWs, "Element 1", 37.65f);
            AssertSignedLine(listUWs, "Element 2", 42.35f);
            AssertSignedLine(listUWs, "Element 3", 20f);
        }

        public void TestMarketSigndown_07_Mins2_2DecimalPlaces_SameResultsAsTest06()
        {

            // test the trivial case.
            market = new Market.Market();
            List<Market.MarketElement> listUWs = new List<Market.MarketElement>
            {
                new Market.MarketElement(10, "Element 1", 80, 20, 0),
                new Market.MarketElement(20, "Element 2", 90, 40, 0),
                new Market.MarketElement(30, "Element 3", 40, 20, 0)
            };

            listUWs = market.MarketSigndown(100, listUWs);

            AssertSignedLine(listUWs, "Element 1", 37.65f);
            AssertSignedLine(listUWs, "Element 2", 42.35f);
            AssertSignedLine(listUWs, "Element 3", 20f);
        }

        public void TestMarketSigndown_08_Mins3_UW2GetsMinSoTheRestForUW1()
        {

            // test the trivial case.
            market = new Market.Market();
            List<Market.MarketElement> listUWs = new List<Market.MarketElement>
            {
                new Market.MarketElement(10, "Element 1", 80, 20, 0),
                new Market.MarketElement(20, "Element 2", 90, 70, 0)
            };

            listUWs = market.MarketSigndown(100, listUWs);

            AssertSignedLine(listUWs, "Element 1", 30f);
            AssertSignedLine(listUWs, "Element 2", 70f);
        }


        public void TestMarketSigndown_09_Mins4_SortUWsBySequenceNumber()
        {

            // test the trivial case.
            market = new Market.Market();
            List<Market.MarketElement> listUWs = new List<Market.MarketElement>
            {
                new Market.MarketElement(10, "Element 1", 80, 20, 0),
                new Market.MarketElement(20, "Element 2", 90, 50, 0),
                new Market.MarketElement(30, "Element 3", 40, 20, 0)
            };

            listUWs = market.MarketSigndown(100, listUWs);

            AssertSignedLine(listUWs, "Element 1", 30f);
            AssertSignedLine(listUWs, "Element 2", 50f);
            AssertSignedLine(listUWs, "Element 3", 20f);
        }

        public void TestMarketSigndown_10_Mins5_MinimumsAreTheSolution()
        {

            // test the trivial case.
            market = new Market.Market();
            List<Market.MarketElement> listUWs = new List<Market.MarketElement>
            {
                new Market.MarketElement(10, "Element 1", 80, 34, 0),
                new Market.MarketElement(20, "Element 2", 90, 33, 0),
                new Market.MarketElement(30, "Element 3", 40, 33, 0)
            };

            listUWs = market.MarketSigndown(100, listUWs);

            AssertSignedLine(listUWs, "Element 1", 34f);
            AssertSignedLine(listUWs, "Element 2", 33f);
            AssertSignedLine(listUWs, "Element 3", 33f);
        }

        public void AssertSignedLine(List<Market.MarketElement> listUWs, string name, float signedLine)
        {
            Market.MarketElement u1 = listUWs.Find(u => u.Name.Equals(name));
            Assert.IsNotNull(u1, " MarketElement " + name + " was not found!");

            Assert.AreEqual(u1.SignedLine, signedLine, 0.1f, " expected signed line for " + name + " is " + signedLine.ToString() + ". It was " + u1.SignedLine.ToString());
        }
    }
}
