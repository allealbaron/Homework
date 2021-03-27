using System;
using System.Text;
using System.Collections.Generic;

namespace PE
{
    /// <summary>
    /// Challenge 01
    /// </summary>
    public class Challenge01
    {
        /// <summary>
        /// Concatenates repetitions and pivot number
        /// </summary>
        /// <param name="repetitions">Repetitions</param>
        /// <param name="pivot">Pivot</param>
        /// <returns>Concatenation</returns>
        private static string AddItemsToLookSay(int repetitions, int pivot)
        {
            return String.Format("{0}{1}",repetitions.ToString() , pivot.ToString());
        }

        /// <summary>
        /// Given a List of <see cref="KeyValuePair{int, int}"/>, returns it
        /// as a string
        /// </summary>
        /// <param name="analyzedNumber">Analyzed number</param>
        /// <returns>List as a string</returns>
        private static string ReprocessList(List<KeyValuePair<int, int>> analyzedNumber)
        {
            StringBuilder result = new();

            foreach (KeyValuePair<int, int> kvp in analyzedNumber)
            {
                result.Append(AddItemsToLookSay(kvp.Key, kvp.Value));
            }

            return result.ToString();

        }

        /// <summary>
        /// Analyze number and returns it as a List of <see cref="KeyValuePair{int, int}"/>
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>List</returns>
        private static List<KeyValuePair<int, int>> AnalyzeNumber(int number)
        {

            List<KeyValuePair<int, int>> result = new();

            string numberAsString = number.ToString();

            int repetitions = 1;

            int pivot = int.Parse(numberAsString[0].ToString());

            int i = 1;

            while (i < numberAsString.Length)
            {
                if (pivot == int.Parse(numberAsString[i].ToString()))
                {
                    repetitions++;
                }
                else
                {
                    result.Add(new KeyValuePair<int, int>(repetitions,pivot));
                    repetitions = 1;
                    pivot = int.Parse(numberAsString[i].ToString());
                }
                i++;
            }

            result.Add(new KeyValuePair<int, int>(repetitions, pivot));

            return result;

        }

        /// <summary>
        /// Given a number, returns a string showing the concatenation of
        /// how many times each digit is repeated and the digit
        /// </summary>
        /// <param name="number">Number to analyze</param>
        /// <returns>Number analayzed</returns>
        public static int LookSay(int number)
        {

            List<KeyValuePair<int, int>> analyzedNumber = AnalyzeNumber(number);

            return int.Parse(ReprocessList(analyzedNumber));

        }

    }
}