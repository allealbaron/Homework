using System;
using System.Collections.Generic;
using System.Linq;

public class DirReduction
{

    private const string NORTE = "NORTE";
    private const string SUR = "SUR";
    private const string OESTE = "OESTE";
    private const string EAST = "ESTE";

    /// <summary>
    /// Given a direction, returns its opposite
    /// </summary>
    /// <param name="direction">Direction</param>
    /// <returns>Opossite</returns>
    private static string GetOpossite(string direction)
    {
        return direction switch
        {
            NORTE => SUR,
            SUR => NORTE,
            OESTE => EAST,
            EAST => OESTE,
            _ => String.Empty,
        };

    }

    /// <summary>
    /// Given a array with directions, reduce it
    /// </summary>
    /// <param name="arr">Array with directions</param>
    /// <returns>Array reduced</returns>
    public static string[] DirReduc(string[] arr)
    {

        List<string> directions = arr.OfType<string>().ToList();

        int i = 0;

        while (i < directions.Count - 1)
        {
            if (directions[i] == GetOpossite(directions[i + 1]))
            {
                directions.RemoveAt(i + 1);
                directions.RemoveAt(i);
                i = 0;
            }
            else
            {
                i++;
            }
        }

        return directions.ToArray();

    }
}