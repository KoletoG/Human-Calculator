using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanCalculator.Interfaces;
using HumanCalculator.Models;
using Moq;

namespace TestingUnits
{
    public class PlayerTests
    {
        private IPlayer player;
        private Mock<IScore> score;
        private Mock<ITime> time;
        public PlayerTests() 
        {
            score = new Mock<IScore>();
            time = new Mock<ITime>();
            player = new Player("TESTING",score.Object);
        }
        [Fact]
        public void GetStats_ReturnsString()
        {
            time.Setup(time => time.ShowAverageTime()).Returns("00:10");
            score.Setup(score => score.CurrentScore).Returns(4);
            score.Setup(score=>score.Time).Returns(time.Object);
            string output = player.GetStats();
            string expected = $"TESTING's score is 4 out of {Score.MaximumScore} with Average time of 00:10";
            Assert.Equal(expected, output);
        }
    }
}
