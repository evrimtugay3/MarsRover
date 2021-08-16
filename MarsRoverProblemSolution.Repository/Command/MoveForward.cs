using MarsRoverMain.Data.Constants;
using MarsRoverMain.Data.Entities;
using System;
using System.Collections.Generic;

namespace MarsRoverMain.Repository.Command
{
    public class MoveForward : Provider.Command
    {
        /// <summary>
        /// maximum limit of rover
        /// </summary>
        private readonly List<int> maxLst = new List<int>();

        /// <summary>
        /// constructor for using maxLst
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="theDirection"></param>
        /// <param name="maxLst"></param>
        public MoveForward(List<int> maxLst)
        {
            this.maxLst = maxLst;
        }

        /// <summary>
        /// execute movement
        /// </summary>
        /// <returns></returns>
        public Coordinates Execute(Coordinates coordinates)
        {
            switch (coordinates.Dir)
            {
                case Directions.N:
                    if (coordinates.Y >= maxLst[1])
                        coordinates = RoverCantMove();
                    else
                        coordinates.Y++;
                    break;

                case Directions.E:
                    if (coordinates.X >= maxLst[0])
                        coordinates = RoverCantMove();
                    else
                        coordinates.X++;
                    break;

                case Directions.S:
                    if (coordinates.Y != 0)
                        coordinates.Y--;
                    else
                        coordinates = RoverCantMove();
                    break;

                case Directions.W:
                    if (coordinates.X != 0)
                        coordinates.X--;
                    else
                        coordinates = RoverCantMove();
                    break;
            }
            return coordinates;
        }

        /// <summary>
        /// Exception Message if Rover can't move
        /// </summary>
        private Coordinates RoverCantMove()
        {
            Console.WriteLine("Rover Can't Move");
            return null;
        }
    }
}