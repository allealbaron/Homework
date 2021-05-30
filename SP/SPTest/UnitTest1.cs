using NUnit.Framework;
using Sp;

namespace sp
{
    public class Tests
    {

        [Test]
        public void Test1()
        {

            string document = "This is a test 123";

            Sp.Processor processor = new();

            Stats stats = processor.Analyze(document);

            Stats rightSolution = new ()
                                    { 
                                        NumberOfWords = 5,
                                        NumberOfWordsOnlyDigits = 1,
                                        NumberOfWordsStartingLowerCase = 3,
                                        NumberOfWordsStartingUpperCase = 1,
                                        LongestWord = "This",
                                        ShortestWord = "a"
                                    };

            Assert.AreEqual(stats.NumberOfWords, rightSolution.NumberOfWords);
            Assert.AreEqual(stats.NumberOfWordsOnlyDigits, rightSolution.NumberOfWordsOnlyDigits);
            Assert.AreEqual(stats.NumberOfWordsStartingLowerCase, rightSolution.NumberOfWordsStartingLowerCase);
            Assert.AreEqual(stats.NumberOfWordsStartingUpperCase, rightSolution.NumberOfWordsStartingUpperCase);
            Assert.AreEqual(stats.LongestWord, rightSolution.LongestWord);
            Assert.AreEqual(stats.ShortestWord, rightSolution.ShortestWord);

        }
    }
}