using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using GlassFillingRobot.Domain;
using GlassFillingRobot.Enums;

namespace GlassFillingRobot.Service
{

    internal interface IPlateauService
    {
        Plateau GetPlateau(int coordinate);
    }
    internal class PlateauService : IPlateauService
    {
        public Plateau GetPlateau(int size)
        {
            var plateau = new Plateau
            {
                Coordinate = new Coordinate(size,size)
            };
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var coordinate = new Coordinate(i,j);
                    var glass = new Glass(coordinate,GlassStateEnum.Empty);
                    plateau.Glasses.Add(glass);
                } 
            }
            return plateau;
        }


    }
}
