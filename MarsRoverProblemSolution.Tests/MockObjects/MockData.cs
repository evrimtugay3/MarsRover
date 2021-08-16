using MarsRoverMain.Data.Entities;
using System;
using System.Collections.Generic;

namespace MarsRoverMain.Tests.MockObjects
{
    /// <summary>
    /// class for mocking data
    /// </summary>
    public static class MockData
    {
        /// <summary>
        /// max coordinates
        /// </summary>
        public static string[] MaxPoints = { "5", "5" };

        /// <summary>
        /// current rover location
        /// </summary>
        public static string[] CurrentLocation = { "1", "2", "N" };

        /// <summary>
        /// commands for moving rover
        /// </summary>
        public static string Movement = "LMLMLMLMM";

        /// <summary>
        /// coordinates of rover location
        /// </summary>
        /// <returns></returns>
        public static Coordinates Coordinates()
        {
            return new Coordinates
            {
                X = 1,
                Y = 2,
                Dir = Data.Constants.Directions.N
            };
        }

        /// <summary>
        /// list of max coordinates
        /// </summary>
        public static List<int> MaxLst => new List<int> { Convert.ToInt32(MaxPoints[0]), Convert.ToInt32(MaxPoints[1]) };
    }
}
