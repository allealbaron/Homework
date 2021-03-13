using System;

public class Challenge
{
    /// <summary>
    /// Concatenates repetitions and pivot number
    /// </summary>
    /// <param name="repetitions">Repetitions</param>
    /// <param name="pivot">Pivot</param>
    /// <returns>Concatenation</returns>
    private static string AddItemsToLookSay(int repetitions, int pivot)
    {
        return repetitions.ToString() + pivot.ToString();
    }

    /// <summary>
    /// Given a number, returns a string showing the concatenation of
    /// how many times each digit is repeated and the digit
    /// </summary>
    /// <param name="number">Number to analyze</param>
    /// <returns>Number analayzed</returns>
    public static int LookSay(int number)
    {
        string result = String.Empty;
        
        string numberAsString = number.ToString();

        int repetitions = 1;
        
        int pivot = int.Parse(numberAsString.Substring(0, 1));
        
        int i = 1;

        while (i < numberAsString.Length)
        {
            if (pivot == int.Parse(numberAsString.Substring(i, 1)))
            {
                repetitions++;
            }
            else
            {
                result += AddItemsToLookSay(repetitions, pivot);
                repetitions = 1;
                pivot = int.Parse(numberAsString.Substring(i, 1));
            }
            i++;
        }

        result += AddItemsToLookSay(repetitions, pivot);

        return int.Parse(result);

    }

}