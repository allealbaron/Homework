namespace Sp
{
    /// <summary>
    /// Stats
    /// </summary>
    public class Stats
    {
        /// <summary>
        /// Number of all words in the document
        /// </summary>
        public int NumberOfWords { get; set; }

        /// <summary>
        /// Number of only digits words
        /// </summary>
        public int NumberOfWordsOnlyDigits { get; set; }

        /// <summary>
        /// Number of words starting with a lower case
        /// </summary>
        public int NumberOfWordsStartingLowerCase { get; set; }

        /// <summary>
        /// Number of words starting with a upper case
        /// </summary>
        public int NumberOfWordsStartingUpperCase { get; set; }

        /// <summary>
        /// Longest word
        /// </summary>
        public string LongestWord { get; set; }

        /// <summary>
        /// Shortest word
        /// </summary>
        public string ShortestWord { get; set; }

    }
}