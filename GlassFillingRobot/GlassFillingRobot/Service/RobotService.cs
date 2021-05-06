using System;
using GlassFillingRobot.Domain;
using GlassFillingRobot.Enums;
using GlassFillingRobot.Helpers;

namespace GlassFillingRobot.Service
{
    internal interface IRobotService
    {
        Robot GetRobot(Plateau plateau);
    }
    internal class RobotService : IRobotService
    {
        public Robot GetRobot(Plateau plateau)
        {
            var coordinate = new Coordinate(0,0);
            var robot = new Robot( coordinate, OrientationEnum.North, plateau);
            return robot;
        }

        //public void MoveRobot(string lineMovement, Robot Robot)
        //{

        //    var movements = lineMovement.ToCharArray();
        //    foreach (var movement in movements)
        //    {

        //        var movementEnum = EnumHelper<MovementEnum>.GetValueFromName(movement.ToString());
            

        //        switch (movementEnum)
        //        {

        //            case MovementEnum.Left:
        //                Robot.Turncounterclockwise();
        //                break;
        //            case MovementEnum.Right:
        //                Robot.TurnRight();
        //                break;
        //            case MovementEnum.Move:
        //                Robot.Move();
        //                break;
        //            default:
        //                Console.WriteLine("Oops! You have not entered a valid movement.");
        //                Console.WriteLine("Enter L to turn left, R to turn right and M to move forward.");
        //                Console.WriteLine("This program will be aborted after you press enter.");
        //                Console.ReadLine();
        //                throw new ArgumentOutOfRangeException();
        //        }
        //    }
        //}
    }
}

