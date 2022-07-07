using FluentAssertions;
using Xunit;

namespace Battleships.Test
{
    public class GameTest
    {
        [Fact]
        public void TestPlay()
       {
            var ships = new[] { "3:2,3:5", "1:2,2:2", "4:3,4:5", "5:0,7:0", "0:8,3:8",  };
            var guesses = new[] { "7:0", "3:2", "3:3", "3:4", "3:5", "4:4","7:7", "1:2","2:2","4:3","4:4","4:5","2:8","3:8" };
            Game.Play(ships, guesses).Should().Be(3);
        }
    }
}
