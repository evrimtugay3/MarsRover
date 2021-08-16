using MarsRoverMain.Data.Constants;
using MarsRoverMain.Data.Entities;
using MarsRoverMain.Repository.Command;
using MarsRoverMain.Repository.Provider;
using MarsRoverMain.Service.Provider;
using System;
using System.Collections.Generic;

namespace MarsRoverMain.Service
{
    public class MarsRoverMainService : IMarsRoverMainService
    {
        /// <summary>
        /// rover movement
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="currentLocation"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        public Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement, Invoker _invoker)
        {
            var maxLst = new List<int>();
            foreach (var m in maxPoints)
            {
                var maxCoordinate = Convert.ToInt32(m);
                maxLst.Add(maxCoordinate);
            }
            var coordinates = new Coordinates();
            coordinates.X = Convert.ToInt32(currentLocation[0]);
            coordinates.Y = Convert.ToInt32(currentLocation[1]);
            coordinates.Dir = currentLocation[2].ToEnumValue<Directions>();
            Command command;

            foreach (var dir in movement)
            {
                switch (dir)
                {
                    case 'L':
                        command = new MoveLeft();
                        break;

                    case 'R':
                        command = new MoveRight();
                        break;

                    case 'M':
                        command = new MoveForward(maxLst);
                        break;

                    default:
                        return null;
                }
                var c = _invoker.StartMoving(command, coordinates);

                if (c == null)
                    return null;

                coordinates.Dir = c.Dir;
                coordinates.X = c.X;
                coordinates.Y = c.Y;
            }
            return coordinates;
        }
    }
}