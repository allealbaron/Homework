namespace RocketLandingOnPlatform
{
    /// <summary>
    /// Coordinate
    /// </summary>
    class Coordinate
    {

        /// <summary>
        /// x
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Stored value
        /// </summary>
        public char StoredValue
        { get; set; }

        /// <summary>
        /// Class builder
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.StoredValue = 'O';
        }

    }
}
