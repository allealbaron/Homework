using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocketLandingOnPlatform
{
    /// <summary>
    /// Grid
    /// </summary>
    class Grid
    {
        /// <summary>
        /// Width
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Length    
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Coordinates
        /// </summary>
        readonly List<Coordinate> coordinates;

        /// <summary>
        /// Class Builder
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="length">Length</param>
        public Grid(int width, int length)
        {
            coordinates = new List<Coordinate>();

            for (int i = 1; i < width + 1; i++)
            {
                for (int k = 1; k < length + 1; k++)
                {
                    coordinates.Add(new Coordinate(k, i));
                }
            }

            this.Width = width;
            this.Length = length;

        }

        /// <summary>
        /// Gets the value from coordenate (x, y)
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>Value</returns>
        public char GetValueFromCoordenate(int x, int y)
        {
            return coordinates.Where(coord => coord.X == x && coord.Y == y)
                              .FirstOrDefault().StoredValue;
        }

        /// <summary>
        /// Sets value from coordenate (x,y)
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="value">new value to assign</param>
        public void SetValueFromCoordenate(int x, int y, char value)
        {
            coordinates.Where(coord => coord.X == x && coord.Y == y)
                       .FirstOrDefault().StoredValue = value;
        }

    }
}
