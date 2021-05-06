using System.Collections.Generic;
using System.Linq;

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
                throw new KeyNotFoundException("Glass is already removed!");
            Glasses.Remove(glass);

        }
    }
}
