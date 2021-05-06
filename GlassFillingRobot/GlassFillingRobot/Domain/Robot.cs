using System;
using System.Linq;
using GlassFillingRobot.Enums;

namespace GlassFillingRobot.Domain
{
    class Robot
    {
        public Robot(Coordinate coordinate, OrientationEnum orientation, Plateau plateau)
        {
            Coordinate = coordinate;
            Orientation = orientation;
            Plateau = plateau;
            IsInsidePlateau = true;
        }

        public bool IsInsidePlateau { get; set; }

        public Coordinate Coordinate { get; set; }

        public OrientationEnum Orientation { get; set; }

        public Plateau Plateau { get; set; }

        internal void TurnCounterClockwise()
        {
            Orientation = Orientation == OrientationEnum.North ? OrientationEnum.East : (OrientationEnum)((int)Orientation  -1);

        }

        internal void TurnClockwise()
        {
            Orientation = Orientation == OrientationEnum.East ? OrientationEnum.North : (OrientationEnum)((int)Orientation + 1);
        }

        internal void Move()
        {
            //get the plateau and the glasses inside
            var plateau = Plateau;
            var glasses = plateau.Glasses;
            var glassInCoordinate = glasses.FirstOrDefault(x => x.Coordinate.X == Coordinate.X && x.Coordinate.Y == Coordinate.Y);
           
            //if there is not any glass in the specified coordinate or if the glass is half full, turn left
            //if glass is empty turn right
            //if glass is full the robot does not need to turn
            if (glassInCoordinate == null)
            {
                TurnCounterClockwise();
            }
            else
            {
                switch (glassInCoordinate.GlassState)
                {
                    case GlassStateEnum.Empty:
                        glassInCoordinate.Fill();
                        TurnClockwise();
                        break;
                    case GlassStateEnum.HalfFull:
                        glassInCoordinate.Fill();
                        TurnCounterClockwise();
                        break;
                    case GlassStateEnum.Full:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            switch (Orientation)
            {
                case OrientationEnum.North:
                    Coordinate.Y--;
                    break;
                case OrientationEnum.West:
                    Coordinate.X++;
                    break;
                case OrientationEnum.South:
                    Coordinate.Y++;
                    break;
                case OrientationEnum.East:
                    Coordinate.X--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (Coordinate.X > Plateau.Coordinate.X || Coordinate.Y > Plateau.Coordinate.Y || Coordinate.X < 0 || Coordinate.Y < 0)
            {
                IsInsidePlateau = false;
            }

        }
    }
}
