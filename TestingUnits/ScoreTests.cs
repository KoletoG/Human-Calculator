using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using HumanCalculator;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestingUnits
{
    public class ScoreTests
    {
        private Mock<ILogger<Score>> _logger;
        private Time _time;
        private Mock<ILogger<Time>> _logger2;
        private Score _score;
        public ScoreTests()
        {
            _logger = new Mock<ILogger<Score>>();
            _logger2 = new Mock<ILogger<Time>>();
            _time = new Time(_logger2.Object);
            _score = new Score(_logger.Object,_logger2.Object,_time);
        }
        [Fact]
        public void AddScore_ScoreIncreases()
        {
            _score.AddScore();
            Assert.Equal(1, _score.CurrentScore);
        }
        [Fact]
        public void AddScore_ThrowsMaximumScoreExceedingException()
        {
            for(int i = 0; i < Score.MaximumScore; i++)
            {
                _score.AddScore();
            }
            Assert.Throws<MaximumScoreExceedingException>(_score.AddScore);
        }
        [Fact]
        public void AddTime_TimeIncreases()
        {
            _score.AddTime(20);
            Assert.Equal(20, _score.Time.Times[0]);
        }
        [Fact]
        public void AddTime_ThrowsIndexOutOfRangeException()
        {
            for(int i = 0; i < Score.MaximumScore; i++)
            {
                _score.AddTime(20);
            }
            Assert.Throws<IndexOutOfRangeException>(() => _score.AddTime(20));
        }
    }
}
