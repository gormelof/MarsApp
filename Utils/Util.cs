using System;
using MarsApp.Enums;
using MarsApp.Mars;

namespace MarsApp.Utils
{
    public class Util
    {
        public static Direction DetectDirectionInput(string direction)
        {
            return direction switch
            {
                "N" => Direction.North,
                "E" => Direction.East,
                "S" => Direction.South,
                "W" => Direction.West,
                _ => throw new Exception("Invalid direction!")
            };
        }

        public static string DetectDirectionOutput(Direction direction)
        {
            return direction switch
            {
                Direction.North => "N",
                Direction.East => "E",
                Direction.South => "S",
                Direction.West => "W",
                _ => throw new Exception("Invalid direction!")
            };
        }
        
        public static bool CheckStartingPosition(Plateau plateau, int pointX, int pointY)
        {
            return pointX <= plateau.Width && pointY <= plateau.Height;
        }
    }
}