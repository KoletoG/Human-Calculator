using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
   public class Score : IScore
    {
        public const int MaximumScore = 5;
        public int CurrentScore { get; private set; } = 0;
        public ITime Time { get; private set; }
        private int currentLoop = 0;
        public Score()
        {
            this.Time = new Time();
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
                Console.WriteLine("Index for Times array was out of range");
            }
            catch (Exception e) {
                Console.WriteLine(e);
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
                Console.WriteLine(e);
            }
        }
    }
}
