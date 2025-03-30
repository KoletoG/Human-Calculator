using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HumanCalculator
{
   public class Score : IScore
    {
        public const int MaximumScore = 5;
        public int CurrentScore { get; private set; } = 0;
        public ITime Time { get; private set; }
        private int currentLoop = 0;
        private ILogger<Score> _logger;
        public Score(ILogger<Score> logger, ILogger<Time> loggerTime)
        {
            this.Time = new Time(loggerTime);
            this._logger = logger;  
        }
        public void AddTime(int seconds)
        {
            try
            {
                this.Time.Times[currentLoop] = seconds;
                currentLoop++;
            }
            catch (IndexOutOfRangeException e)
            {
                _logger.LogError("Index for Times array was out of range");
            }
            catch (Exception e) {
                _logger.LogError(e.ToString());
            }
        }
        public void AddScore()
        {
            try
            {
                if (this.CurrentScore >= MaximumScore)
                {
                    throw new MaximumScoreExceedingException(this.CurrentScore);
                }
                this.CurrentScore++;
            }
            catch(MaximumScoreExceedingException e)
            {
                _logger.LogError(e.ToString());
            }
        }
    }
}
