using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace HumanCalculator
{
   public class Time : ITime
    {
        public int[] Times { get; private set; }
        public int AverageTime { get; private set; }
        private ILogger<Time> _logger;
        public Time(ILogger<Time> logger)
        {
            Times = new int[Score.MaximumScore];
            _logger= logger;
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
                _logger.LogError(e.ToString());
            }
        }
        public string ShowAverageTime()
        {
            return TimeSpan.FromSeconds(AverageTime).ToString(@"mm\:ss");
        }
    }
}
