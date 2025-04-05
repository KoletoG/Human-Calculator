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
        /// <summary>
        /// Calculates the average time of all the completed times
        /// </summary>
        public void CalcAverageTime()
        {
            try
            {
                checked
                {
                    int allTime = 0;
                    foreach (int t in Times)
                    {
                        allTime += t;
                    }
                    this.AverageTime = allTime / Score.MaximumScore;
                }
            }
            catch (OverflowException e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        /// <summary>
        /// Shows the average time
        /// </summary>
        /// <returns>String with the average time formulated by minutes and seconds</returns>
        public string ShowAverageTime()
        {
            return TimeSpan.FromSeconds(AverageTime).ToString(@"mm\:ss");
        }
    }
}
