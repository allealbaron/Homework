namespace RocketLandingOnPlatform
{
    class Platform
    {
        /// <summary>
        /// Out of platform
        /// </summary>
        private const char OUT_OF_PLATFORM = 'O';

        /// <summary>
        /// Clash
        /// </summary>
        private const char CLASH = 'C';

        /// <summary>
        /// Ok for landing
        /// </summary>
        private const char OK_FOR_LANDING = 'L';

        /// <summary>
        /// Platform Grid
        /// </summary>
        private readonly Grid PlatformGrid;

        /// <summary>
        /// Class builder
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="length">Length</param>
        /// <param name="landingZoneBegin">Top left landing zone's coordenate</param>
        /// <param name="landingZoneWidth">Landing zone's width</param>
        /// <param name="landingZoneLength">Landing zone's length</param>
        public Platform(int width, int length, 
                        Coordinate landingZoneBegin, 
                        int landingZoneWidth, int landingZoneLength)
        {
            
            PlatformGrid = new Grid(width, length);

            for (int i = landingZoneBegin.X; i < landingZoneBegin.X + landingZoneWidth; i++)
            {
                for (int j = landingZoneBegin.Y; j < landingZoneBegin.Y + landingZoneLength; j++)
                {
                    PlatformGrid.SetValueFromCoordenate(i, j, OK_FOR_LANDING);
                }
            }

        }

        /// <summary>
        /// Set an item and its surroundings with a new value
        /// </summary>
        /// <param name="coordinate">Coordinates</param>
        /// <param name="newValue">New value</param>
        private void SetItemAndSurroundings(Coordinate coordinate, char newValue)
        {

            PlatformGrid.SetValueFromCoordenate(coordinate.X, coordinate.Y, newValue);

            if (coordinate.X > 1)
            {
                if (PlatformGrid.GetValueFromCoordenate(coordinate.X - 1, coordinate.Y) != OUT_OF_PLATFORM)
                {
                    PlatformGrid.SetValueFromCoordenate(coordinate.X - 1, coordinate.Y, newValue);
                }

                if (coordinate.Y > 1 && PlatformGrid.GetValueFromCoordenate(coordinate.X - 1, coordinate.Y - 1) != OUT_OF_PLATFORM)
                {
                    PlatformGrid.SetValueFromCoordenate(coordinate.X - 1, coordinate.Y - 1, newValue);
                }

                if (coordinate.Y < PlatformGrid.Length && PlatformGrid.GetValueFromCoordenate(coordinate.X - 1, coordinate.Y + 1) != OUT_OF_PLATFORM)
                {
                    PlatformGrid.SetValueFromCoordenate(coordinate.X - 1, coordinate.Y + 1, newValue);
                }

            }

            if (coordinate.Y > 1 && PlatformGrid.GetValueFromCoordenate(coordinate.X, coordinate.Y - 1) != OUT_OF_PLATFORM)
            {
                PlatformGrid.SetValueFromCoordenate(coordinate.X, coordinate.Y - 1, newValue);
            }

            if (coordinate.Y < PlatformGrid.Length && PlatformGrid.GetValueFromCoordenate(coordinate.X, coordinate.Y + 1) != OUT_OF_PLATFORM)
            {
                PlatformGrid.SetValueFromCoordenate(coordinate.X, coordinate.Y + 1, newValue);
            }

            if (coordinate.X < PlatformGrid.Width)
            {

                if (PlatformGrid.GetValueFromCoordenate(coordinate.X + 1, coordinate.Y) != OUT_OF_PLATFORM)
                {
                    PlatformGrid.SetValueFromCoordenate(coordinate.X + 1, coordinate.Y, newValue);
                }

                if (coordinate.Y > 1 && PlatformGrid.GetValueFromCoordenate(coordinate.X + 1, coordinate.Y - 1) != OUT_OF_PLATFORM)
                {
                    PlatformGrid.SetValueFromCoordenate(coordinate.X + 1, coordinate.Y - 1, newValue);
                }

                if (coordinate.Y < PlatformGrid.Length && PlatformGrid.GetValueFromCoordenate(coordinate.X + 1, coordinate.Y + 1) != OUT_OF_PLATFORM)
                {
                    PlatformGrid.SetValueFromCoordenate(coordinate.X + 1, coordinate.Y + 1, newValue);
                }

            }

        }

        /// <summary>
        /// Sets Free a position
        /// </summary>
        /// <param name="askedCoordinate">Position to set free</param>
        public void FreePosition(Coordinate askedCoordinate)
        {

            SetItemAndSurroundings(askedCoordinate, OK_FOR_LANDING);

        }

        /// <summary>
        /// Ask for a position
        /// </summary>
        /// <param name="askedCoordinate">Coordinate to ask</param>
        /// <returns>Can returns three values: O (Out of platform), C (Clash) or L (Ok for Landing)</returns>
        public char AskPosition(Coordinate askedCoordinate)
        {
            char storedValue = PlatformGrid.GetValueFromCoordenate(askedCoordinate.X, askedCoordinate.Y);

            if (storedValue.Equals(OK_FOR_LANDING))
            {

                SetItemAndSurroundings(askedCoordinate, CLASH);

            }

            return storedValue;

        }

    }
}
