using MarsRoverMain.Data.Entities;

namespace MarsRoverMain.Repository.Invoker
{
    public class ExecuteAction : Provider.Invoker
    {
        /// <summary>
        /// start movement of rover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Coordinates StartMoving(Provider.Command command, Coordinates coordinates)
        {
            return command.Execute(coordinates);
        }
    }
}