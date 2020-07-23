using System;
using MarsApp.Enums;

namespace MarsApp.Mars
{
    public class Rover
    {
        public int PointX { get; set; }
        public int PointY { get; set; }
        public Direction Direction { get; set; }
        
        private const char LEFT = 'L';
        private const char RIGHT = 'R';
        private const char MOVE = 'M';

        public Rover(int pointX, int pointY, Direction direction)
        {
            PointX = pointX;
            PointY = pointY;
            Direction = direction;
        }
        
        private void Left()
        {
            Direction = (Direction - 1) < Direction.North ? Direction.West : Direction - 1;
        }

        private void Right()
        {
            Direction = (Direction + 1) > Direction.West ? Direction.North : Direction + 1;
        }

        private void Move()
        {
            switch (Direction)
            {
                case Direction.North:
                    PointY++;
                    break;
                case Direction.East:
                    PointX++;
                    break;
                case Direction.South:
                    PointY--;
                    break;
                case Direction.West:
                    PointX--;
                    break;
            }
        }

        public void ExecuteCommand(string command, Plateau plateau)
        {
            foreach (var c in command)
            {
                switch (c)
                {
                    case LEFT:
                        Left();
                        break;
                    case RIGHT:
                        Right();
                        break;
                    case MOVE:
                    {
                        Move();
                        if (PointX > plateau.Width || PointY > plateau.Height)
                        {
                            throw new Exception("The rover cannot out of the plateau!");
                        }

                        break;
                    }
                }
            }
        }
    }
}