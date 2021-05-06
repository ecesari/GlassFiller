using System;
using System.Collections.Generic;
using System.Text;
using GlassFillingRobot.Enums;

namespace GlassFillingRobot.Domain
{
    internal class Glass
    {
        public Glass(Coordinate coordinate,GlassStateEnum glassState)
        {
            Coordinate = coordinate;
            GlassState = glassState;
        }

        public Coordinate Coordinate { get; set; }

        public GlassStateEnum GlassState { get; set; }

        internal void Fill()
        {
            switch (GlassState)
            {
                case GlassStateEnum.Empty:
                    GlassState = GlassStateEnum.HalfFull;
                    break;
                case GlassStateEnum.HalfFull:
                    GlassState = GlassStateEnum.Full;
                    break;
                case GlassStateEnum.Full:
                    throw new ArgumentOutOfRangeException($"Glass is already full!");
                case GlassStateEnum.Removed:
	                break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}
