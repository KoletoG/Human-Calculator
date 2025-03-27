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
    }
}
