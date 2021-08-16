using FakeItEasy;
using MarsRoverMain.Data.Entities;
using MarsRoverMain.Repository.Provider;
using MarsRoverMain.Service;
using MarsRoverMain.Service.Provider;
using MarsRoverMain.Tests.MockObjects;
using Xunit;

namespace MarsRoverMain.Tests.Service_Test
{
    public class MarsRoverMainServiceTest
    {
        /// <summary>
        /// invoker reference
        /// </summary>
        private readonly Invoker _invoker;

        /// <summary>
        /// IMarsRoverMainService reference
        /// </summary>
        private readonly IMarsRoverMainService _MarsRoverMainService;

        /// <summary>
        /// constructor for instantiating references
        /// </summary>
        public MarsRoverMainServiceTest()
        {
            _invoker = A.Fake<Invoker>();
            _MarsRoverMainService = new MarsRoverMainService();
        }

        /// <summary>
        /// test for MoveRoverSync method
        /// </summary>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MoveRoverSync_Test(bool isCoordinateNull)
        {
            //Arrange
            var maxPoints = MockData.MaxPoints;
            var currentLocation = MockData.CurrentLocation;
            var movement = MockData.Movement;
            var coordinates = MockData.Coordinates();
            if (!isCoordinateNull)
                A.CallTo(() => _invoker.StartMoving(A<Command>._, A<Coordinates>._)).ReturnsLazily(() => coordinates);
            else
                A.CallTo(() => _invoker.StartMoving(A<Command>._, A<Coordinates>._)).ReturnsLazily(() => null);

            //Act
            var result = _MarsRoverMainService.MoveRoverSync(maxPoints, currentLocation, movement, _invoker);

            //Assert
            if (!isCoordinateNull)
            {
                Assert.NotNull(result);
                Assert.Equal(coordinates.X, result.X);
                Assert.Equal(coordinates.Y, result.Y);
                Assert.Equal(coordinates.Dir, result.Dir);
            }
            else
            {
                Assert.Null(result);
            }
        }
    }
}