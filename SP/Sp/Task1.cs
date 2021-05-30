using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Sp
{
    /// <summary>
    /// Document Processor
    /// </summary>
    public class Processor
    {
        /// <summary>
        /// Analyzes the document.
        /// </summary>
        /// <exception cref="ArgumentNullException">document is null</exception>
        public Stats Analyze(string document)
        {
            if (document is null)
            {

                ArgumentNullException argumentNullException = new("Document is null");
                throw argumentNullException;

            }
            else
            {                
                if (!String.IsNullOrWhiteSpace(document))
                {
                    this.words = document.Split(" ").ToList();
                }

                Stats solution = new ()
                {
                    NumberOfWords = GetNumberOfWords(),                    
                    NumberOfWordsOnlyDigits = GetNumberOfWordsOnlyDigits(),                    
                    NumberOfWordsStartingLowerCase = GetNumberOfWordsStartingLowerCase(),                    
                    NumberOfWordsStartingUpperCase = GetNumberOfWordsStartingUpperCase(),
                    LongestWord = GetLongestWord(),
                    ShortestWord = GetShortestWord()
                };
                
                return solution;                

            }

        }

        /// <summary>
        /// Words
        /// </summary>
        private List<string> words = new();

        /// <summary>
        /// Returns if a word is only numbers
        /// </summary>
        /// <param name="word">Word</param>
        /// <returns>True if every char is a number</returns>
        private static bool IsOnlyNumber(string word)
        {
            Regex regexNumber = new ("^[0-9]+$");

            return regexNumber.IsMatch(word);

        }

        /// <summary>
        /// Returns if a word begins with lower case
        /// </summary>
        /// <param name="word">Word</param>
        /// <returns>True if the first char is lower case</returns>
        private static bool BeginWithLowerCase(string word)
        {
            Regex regexNumber = new("^[a-z]");

            return regexNumber.IsMatch(word);

        }

        /// <summary>
        /// Returns if a word begins with upper case
        /// </summary>
        /// <param name="word">Word</param>
        /// <returns>True if the first char is upper case</returns>
        private static bool BeginWithUpperCase(string word)
        {
            Regex regexNumber = new("^[A-Z]");

            return regexNumber.IsMatch(word);

        }

        /// <summary>
        /// Return number of words in the document
        /// </summary>
        /// <returns>Number of words</returns>
        public int GetNumberOfWords()
        {
            return words.Count;
        }


        /// <summary>
        /// Return number of only digit words in the document
        /// </summary>
        /// <returns>Number of only digit words </returns>
        public int GetNumberOfWordsOnlyDigits()
        {
            return (from word in words where IsOnlyNumber(word) select word).Count();
        }

        /// <summary>
        /// Return number of only digit words in the document
        /// </summary>
        /// <returns>Number of only digit words </returns>
        public int GetNumberOfWordsStartingLowerCase()
        {
            return (from word in words where BeginWithLowerCase(word) select word).Count();
        }



        /// <summary>
        /// Return number of only digit words in the document
        /// </summary>
        /// <returns>Number of only digit words </returns>
        public int GetNumberOfWordsStartingUpperCase()
        {
            return (from word in words where BeginWithUpperCase(word) select word).Count();
        }

        /// <summary>
        /// Returns the longest word
        /// </summary>
        /// <returns>The longest word</returns>
        public string GetLongestWord()
        {
            return (from w in words.Select((word, index) => new { word, index }) select w)
                   .OrderByDescending(t => t.word.Length).ThenBy(t => t.index).Select(t => t.word).FirstOrDefault();
        }

        /// <summary>
        /// Returns the shortest word
        /// </summary>
        /// <returns>The shortest word</returns>
        public string GetShortestWord()
        {
            return (from w in words.Select((word, index) => new { word, index }) select w)
                   .OrderBy(t => t.word.Length).ThenBy(t => t.index).Select(t => t.word).FirstOrDefault();
        }

    }
}

