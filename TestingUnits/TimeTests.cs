using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanCalculator.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestingUnits
{
    public class TimeTests
    {
        private Mock<ILogger<Time>> _logger;
        private Time Time;
        public TimeTests()
        {
            _logger = new Mock<ILogger<Time>>();
            Time = new Time(_logger.Object);
        }
        [Fact]
        public void CalcAverageTime_ComputesAccurateAverage()
        {
            for (int i = 0; i < Score.MaximumScore; i++)
            {
                Time.Times[i] = 10;
            }
            Time.CalcAverageTime();
            Assert.Equal(10, Time.AverageTime);
        }
        [Fact]
        public void CalcAverageTime_ThrowsOverflowException()
        {
            for (int i = 0; i < Score.MaximumScore; i++)
            {
                Time.Times[i] = int.MaxValue;
            }
            Assert.Throws<OverflowException>(Time.CalcAverageTime);
        }
        [Fact]
        public void ShowAverageTime_ReturnsStringWithAverageTime()
        {
            for (int i = 0; i < Score.MaximumScore; i++)
            {
                Time.Times[i] = 10;
            }
            Time.CalcAverageTime();
            string output = Time.ShowAverageTime();
            Assert.Contains("00:10", output);
        }
    }
}
