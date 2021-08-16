using MarsRoverMain.Data.Constants;
using MarsRoverMain.Data.Entities;

namespace MarsRoverMain.Repository.Command
{
    public class MoveLeft : Provider.Command
    {
        /// <summary>
        /// execute rotation
        /// </summary>
        /// <returns></returns>
        public Coordinates Execute(Coordinates coordinates)
        {
            switch (coordinates.Dir)
            {
                case Directions.N:
                    coordinates.Dir = Directions.W;
                    break;

                case Directions.E:
                    coordinates.Dir = Directions.N;
                    break;

                case Directions.S:
                    coordinates.Dir = Directions.E;
                    break;

                case Directions.W:
                    coordinates.Dir = Directions.S;
                    break;
            }
            return coordinates;
        }
    }
}