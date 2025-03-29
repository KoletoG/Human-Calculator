using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
   public class Score : IScore
    {
        public const int MaximumScore = 5;
        public int CurrentScore { get; private set; } = 0;
        public ITime Time { get; private set; }
        private int currentLoop = 0;
        public Score()
        {
            this.Time = new Time();
        }
        public void AddTime(int seconds)
        {
            this.Time.Times[currentLoop]=seconds;
            currentLoop++;
        }
        public void AddScore()
        {
            if (this.CurrentScore >= MaximumScore)
            {
                throw new MaximumScoreExceedingException(this.CurrentScore);
            }
            this.CurrentScore++;
        }
    }
}
