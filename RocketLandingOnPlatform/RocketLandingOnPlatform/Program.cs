using System;

namespace RocketLandingOnPlatform
{
    class Program
    {
        static void Main()
        {

            Platform platform = new Platform(100, 100, new Coordinate(1, 1), 10, 10);

            Console.WriteLine("Position (5,5): {0} (Should answer L)", platform.AskPosition(new Coordinate(5,5)));

            Console.WriteLine("Position (16,15): {0} (Should answer O)", platform.AskPosition(new Coordinate(16, 15)));

            Console.WriteLine("Position (5,5): {0} (Should answer C)", platform.AskPosition(new Coordinate(5, 5)));

            Console.WriteLine("Position (5,6): {0} (Should answer C)", platform.AskPosition(new Coordinate(5, 6)));

            platform.FreePosition(new Coordinate(5, 5));

            Console.WriteLine("Position (5,6): {0} (Should answer L)", platform.AskPosition(new Coordinate(5, 6)));

        }
    }
}
