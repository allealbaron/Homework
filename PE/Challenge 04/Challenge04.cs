using System;
using System.Collections.Generic;
using System.Linq;

namespace PE
{
    /// <summary>
    /// Challenge 04
    /// </summary>
    public class DirReduction
    {

        /// <summary>
        /// Cardinal points
        /// </summary>
        public enum CardinalPoints
        { 
            NORTE,
            SUR,
            OESTE,
            ESTE
        }

        /// <summary>
        /// Dictionary with opposites
        /// </summary>
        private static readonly Dictionary<CardinalPoints, CardinalPoints> Opposites= new()
        {
                { CardinalPoints.NORTE, CardinalPoints.SUR },
                { CardinalPoints.SUR, CardinalPoints.NORTE },
                { CardinalPoints.ESTE, CardinalPoints.OESTE },
                { CardinalPoints.OESTE, CardinalPoints.ESTE }
        };

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
                _ = Enum.TryParse(directions[i], out CardinalPoints firstItem);
                _ = Enum.TryParse(directions[i + 1], out CardinalPoints secondItem);

                if (Opposites[firstItem] == secondItem)
                {
                    directions.RemoveAt(i + 1);
                    directions.RemoveAt(i);
                    i -= 2;
                    if (i < 0)
                    {
                        i = 0;
                    }
                }
                else
                {
                    i++;
                }
            }

            return directions.ToArray();

        }
    }
}