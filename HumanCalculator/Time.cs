using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
   public class Time : ITime
    {
        public int[] Times { get; private set; }
        public int AverageTime { get; private set; }
        public Time()
        {
            Times = new int[Score.MaximumScore];
        }
        public void CalcAverageTime()
        {
            try
            {
                int allTime = 0;
                foreach (int t in Times)
                {
                    allTime += t;
                }
                this.AverageTime = allTime / Score.MaximumScore;
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Time exceeded any limit");
            }
        }
        public string ShowAverageTime()
        {
            return TimeSpan.FromSeconds(AverageTime).ToString(@"mm\:ss");
        }
    }
}
