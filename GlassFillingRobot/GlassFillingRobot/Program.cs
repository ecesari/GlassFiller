using System;
using System.Linq;
using GlassFillingRobot.Domain;
using GlassFillingRobot.Enums;
using GlassFillingRobot.Helpers;
using GlassFillingRobot.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GlassFillingRobot
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            //Registration of Services
            RegisterServices();

            var robotService = _serviceProvider.GetService<IRobotService>();
            var plateauService = _serviceProvider.GetService<IPlateauService>();


            //Create plateau by user input
            Console.WriteLine("Enter plateau size:");
            var plateauLine = Console.ReadLine();
            var plateauSize = Convert.ToInt32(plateauLine);
            var plateau = plateauService.GetPlateau(plateauSize);

			//Remove glasses at indicated coordinates
			Console.WriteLine("Enter coordinates of glasses to be removed, you must place a single space between each character");
			Console.WriteLine("1 1 0 1 would remove the glasses at point 1,1 and 0,1"); var lineGlass = Console.ReadLine();
			var lineArray = lineGlass.GetIntArrayByString();
			for (var i = 0; i < lineArray.Length; i++)
			{
				if (i % 2 == 1)
					continue;
				if (i + 1 >= lineArray.Length)
					throw new ArgumentOutOfRangeException();

				var coordinate = new Coordinate(lineArray[i], lineArray[i + 1]);
				plateau.RemoveGlass(coordinate);
			}

			//You can ask for robot's coordinates and orientation but for this instance the starting point is 0*0 and direction is North
			//Console.WriteLine("Enter robot's coordinates and orientation:");
			var robot = Robot(robotService, plateau);

            //continue to move the robot if there are any glasses unfilled
            //if robot is outside the plateau boundaries the program is finished
            while (robot.IsInsidePlateau)
                robot.Move();

            var plateauFinished = plateau.Glasses.Count(x => x.GlassState != GlassStateEnum.Full) == 0;

			if (plateauFinished)
			{
				Console.WriteLine("Success! The robot has fil!ed all the glasses");

			}
			else
			{
				Console.WriteLine("The robot has failed to fill all the glasses :(");
				Console.WriteLine("Press enter to find the locations of the glasses to be removed");
				Console.ReadLine();
				robot.FindSoution();
			}
			Console.ReadLine();
        }

        private static Robot Robot(IRobotService robotService, Plateau plateau)
        {
            var robot = robotService.GetRobot(plateau);
            return robot;
        }


        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IRobotService, RobotService>();
            collection.AddScoped<IPlateauService, PlateauService>();
            collection.AddScoped<ICoordinateService, CoordinateService>();
            _serviceProvider = collection.BuildServiceProvider();
        }
    }
}