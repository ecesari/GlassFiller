using System.Collections.Generic;
using System.Linq;
using GlassFillingRobot.Enums;

namespace GlassFillingRobot.Domain
{
    internal class Plateau
    {
        public Plateau()
        {
            Glasses = new List<Glass>();
        }
        public Coordinate Coordinate { get; set; }
        public IList<Glass> Glasses { get; set; }

        public void RemoveGlass(Coordinate coordinate)
        {
            var glass = Glasses.FirstOrDefault(g => g.Coordinate.X == coordinate.X && g.Coordinate.Y == coordinate.Y);
            if (glass == null)
                throw new KeyNotFoundException("There is no glass generated at this location!");
            glass.GlassState = GlassStateEnum.Removed;

        }
    }
}
