using FluentAssertions;
using System;
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

        [Fact]
        public void Test_Ship_Is_Null()
        {
            var guesses = new[] { "7:0", "3:2", "3:3", "3:4", "3:5", "4:4", "7:7", "1:2", "2:2", "4:3", "4:4", "4:5", "2:8", "3:8" };
            Assert.Throws<ArgumentNullException>(() => Game.Play(null, guesses));
        }

        [Fact]
        public void Test_Guess_Is_Null()
        {
            var ships = new[] { "3:2,3:5", "1:2,2:2", "4:3,4:5", "5:0,7:0", "0:8,3:8", };
            Assert.Throws<ArgumentNullException>(() => Game.Play(ships, null));
        }

        [Fact]
        public void Test_Input_Params_Are_Null()
        {
            Assert.Throws<ArgumentNullException>(() => Game.Play(null, null));
        }

        [Fact]
        public void Test_Invalid_Input_Ships_Parameters()
        {
            var ships = new[] { "32,35", "1:2,2:2", "4:3,4:5", "5:0,7:0", "0:8,3:8", };
            var guesses = new[] { "70", "3:2", "3:3", "3:4", "3:5", "4:4", "7:7", "1:2", "2:2", "4:3", "4:4", "4:5", "2:8", "3:8" };
            Assert.Throws<InvalidOperationException>(() => Game.Play(ships, guesses));
        }
        [Fact]
        public void Test_Invalid_Input_Guesses_Parameters()
        {
            var ships = new[] { "3:2,3:5", "1:2,2:2", "4:3,4:5", "5:0,7:0", "0:8,3:8", };
            var guesses = new[] { "70", "3:2", "3:3", "3:4", "3:5", "4:4", "7:7", "1:2", "2:2", "4:3", "4:4", "4:5", "2:8", "3:8" };
            Assert.Throws<InvalidOperationException>(() => Game.Play(ships, guesses));
        }
        [Fact]
        public void Test_Invalid_Input_Parameters()
        {
            var ships = new[] { "32,35", "1:2,2:2", "4:3,4:5", "5:0,7:0", "0:8,3:8", };
            var guesses = new[] { "70", "3:2", "3:3", "3:4", "3:5", "4:4", "7:7", "1:2", "2:2", "4:3", "4:4", "4:5", "2:8", "3:8" };
            Assert.Throws<InvalidOperationException>(() => Game.Play(ships, guesses));
        }
    }
}
