using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanCalculator.Exceptions;
using HumanCalculator.Interfaces;
using Microsoft.Extensions.Logging;

namespace HumanCalculator.Models
{
   public class Score : IScore
    {
        public const int MaximumScore = 5;
        public int CurrentScore { get; private set; } = 0;
        public ITime Time { get; private set; }
        private int currentLoop = 0;
        private ILogger<Score> _logger;
        public Score(ILogger<Score> logger, ILogger<Time> loggerTime, ITime time)
        {
            Time = time;
            _logger = logger;  
        }
        /// <summary>
        /// Adds the completed time of the calculation
        /// </summary>
        /// <param name="seconds">Time of the calculation</param>
        public void AddTime(int seconds)
        {
            try
            {
                Time.Times[currentLoop] = seconds;
                currentLoop++;
            }
            catch (IndexOutOfRangeException)
            {
                _logger.LogError("Index for Times array was out of range");
                throw;
            }
            catch (Exception e) {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        /// <summary>
        /// Adds successful attempts to score
        /// </summary>
        public void AddScore()
        {
            try
            {
                if (CurrentScore >= MaximumScore)
                {
                    throw new MaximumScoreExceedingException(CurrentScore);
                }
                CurrentScore++;
            }
            catch(MaximumScoreExceedingException e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
    }
}
