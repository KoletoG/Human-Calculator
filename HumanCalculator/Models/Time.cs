﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanCalculator.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace HumanCalculator.Models
{
    public class Time : ITime
    {
        public int[] Times { get; private set; }
        public int AverageTime { get; private set; }
        private readonly ILogger<Time> _logger;
        public Time(ILogger<Time> logger)
        {
            Times = new int[Score.MaximumScore];
            _logger = logger;
        }
        public void SetTimeArray()
        {
            Times = new int[Score.MaximumScore];
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
                    for (int i = 0; i < Times.Length; i++)
                    {
                        allTime += Times[i];
                    }
                    AverageTime = allTime / Score.MaximumScore;
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
