using System;
using System.Collections.Generic;
using MarsApp.InputValidation;
using MarsApp.Mars;
using MarsApp.Utils;

namespace MarsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var upperRight = Console.ReadLine();
            IInputValidation inputValidation = new CoordinateInputValidation(upperRight);

            if (!inputValidation.IsValid())
            {
                throw new Exception("Invalid upper-right coordinate!");
            }

            var upperRightValues = upperRight.Split(" ");
            var plateau = new Plateau
            {
                Width = int.Parse(upperRightValues[0]),
                Height = int.Parse(upperRightValues[1]),
                Rovers = new List<Rover>()
            };

            var selection = "Y";
            while (selection == "Y")
            {
                var position = Console.ReadLine();
                inputValidation = new PositionInputValidation(position);

                if (inputValidation.IsValid() == false)
                {
                    throw new Exception("Invalid position!");
                }
                
                var positionValues = position.Split(" ");
                var pointX = int.Parse(positionValues[0]);
                var pointY = int.Parse(positionValues[1]);
                var direction = Util.DetectDirectionInput(positionValues[2]);

                if (Util.CheckStartingPosition(plateau, pointX, pointY) == false)
                {
                    throw new Exception("Rover's starting position must be inside the plateau!");
                }
                
                var rover = new Rover(pointX, pointY, direction);
                
                var command = Console.ReadLine();
                inputValidation = new CommandInputValidation(command);

                if (!inputValidation.IsValid())
                {
                    throw new Exception("Invalid command!");
                }
                
                rover.ExecuteCommand(command, plateau);
                plateau.Rovers.Add(rover);

                Console.WriteLine("Do you want to continue adding the rover? 'Y' or 'N'");
                selection = Console.ReadLine();
            }

            foreach (var rover in plateau.Rovers)
            {
                Console.WriteLine(rover.PointX + " " + rover.PointY + " " + Util.DetectDirectionOutput(rover.Direction));
            }
        }
    }
}