using HumanCalculator;

namespace TestingUnits
{
    public class UnitTest1
    {
        [Fact]
        public void CalcAverageTime_WhenDividingByFive_ReturnsExpectedResult()
        {
            Score score = new Score();
            score.AddTime(60);
            score.AddTime(140);
            score.Time.CalcAverageTime();
            Assert.Equal(40, score.Time.AverageTime);
        }
        [Theory]
        [InlineData(160,140,60)]
        [InlineData(180, 120, 60)]
        [InlineData(260, 240, 100)]
        public void CalcAverageTime_WhenDividingByFive_ReturnsPossibleResult(int a, int b, int expected)
        {
            Score score = new Score();
            score.AddTime(a);
            score.AddTime(b);
            score.Time.CalcAverageTime();
            Assert.Equal(expected, score.Time.AverageTime);
        }
        [Fact]
        public void AddingScore_ByOne_ReturnsExpectedResult()
        {
            Score score = new Score();
            score.AddScore();
            Assert.Equal(1, score.CurrentScore);
        }
        [Fact]
        public void AddingScore_OverMaximumScore_ThrowsException()
        {
            Score score = new Score();
            for(int i = 0; i < Score.MaximumScore; i++)
            {
                score.AddScore();
            }
            Assert.Throws<MaximumScoreExceedingException>(() => score.AddScore());
        }
    }
}
