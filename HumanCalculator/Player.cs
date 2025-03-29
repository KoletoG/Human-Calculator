using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
    class Player : IPlayer
    {
        public char[] Name { get; private set; }
        public IScore PlayerScore { get; private set; }
        public Player(char[] name, IScore score)
        {
            this.Name = name;
            this.PlayerScore = score;
        }
        public string GetStats()
        {
            return $"{Name}'s score is {PlayerScore.CurrentScore} out of {Score.MaximumScore} with Average time of {PlayerScore.Time.ShowAverageTime()}";
        }
    }
}
