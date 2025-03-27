using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
   public class Score : IScore
    {
        public readonly static byte MaximumScore = 5;
        public byte CurrentScore { get; set; } = 0;
        public ITime Time { get; private set; }
        public Score()
        {
            this.Time = new Time();
        }
        public void AddTime(double seconds)
        {
            this.Time.Times.Add(seconds);
        }
        public void AddScore()
        {
            this.CurrentScore++;
        }
    }
}
