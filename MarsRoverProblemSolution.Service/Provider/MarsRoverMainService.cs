using MarsRoverMain.Data.Entities;
using MarsRoverMain.Repository.Provider;

namespace MarsRoverMain.Service.Provider
{
    public interface IMarsRoverMainService
    {
        /// <summary>
        /// rover movement
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="currentLocation"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement, Invoker _invoker);
    }
}
