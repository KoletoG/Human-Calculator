using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
    class Time : ITime
    {
        public List<double> Times { get; private set; }
        public double AverageTime { get; private set; }
        public Time()
        {
            Times = new List<double>();
        }
        public void CalcAverageTime()
        {
            double allTime = 0;
            foreach (double t in Times)
            {
                allTime += t;
            }
            this.AverageTime = allTime / Score.MaximumScore;
        }
        public string ShowAverageTime()
        {
            return TimeSpan.FromSeconds(AverageTime).ToString(@"mm\:ss");
        }
    }
}
