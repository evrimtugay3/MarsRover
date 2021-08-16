using MarsRoverMain.Data.Constants;

namespace MarsRoverMain.Data.Entities
{
    public class Coordinates
    {
        /// <summary>
        /// x coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// y coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// rover facing direction
        /// </summary>
        public Directions Dir { get; set; }
    }
}