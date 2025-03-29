using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
   public class Time : ITime
    {
        public byte[] Times { get; private set; }
        public byte AverageTime { get; private set; }
        public Time()
        {
            Times = new byte[Score.MaximumScore];
        }
        public void CalcAverageTime()
        {
            short allTime = 0;
            foreach (byte t in Times)
            {
                allTime += t;
            }
            this.AverageTime = (byte)(allTime / Score.MaximumScore);
        }
        public string ShowAverageTime()
        {
            return TimeSpan.FromSeconds(AverageTime).ToString(@"mm\:ss");
        }
    }
}
