using System;
using System.Collections.Generic;
using System.Text;
using GlassFillingRobot.Domain;

namespace GlassFillingRobot.Service
{

    internal interface ICoordinateService
    {
        Coordinate GetCoordinate(int x, int y);
    }

    internal class CoordinateService : ICoordinateService
    {
        public Coordinate GetCoordinate(int x, int y)
        {
            return new Coordinate(x, y);
        }
    }
}
