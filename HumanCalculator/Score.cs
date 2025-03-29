using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
   public class Score : IScore
    {
        public const byte MaximumScore = 5;
        public byte CurrentScore { get; private set; } = 0;
        public ITime Time { get; private set; }
        private byte currentLoop = 0;
        public Score()
        {
            this.Time = new Time();
        }
        public void AddTime(double seconds)
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
