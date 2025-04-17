using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanCalculator.Interfaces;

namespace HumanCalculator.Models
{
    public class Player : IPlayer
    {
        public string Name { get; private init; }
        public IScore PlayerScore { get; private init; }
        public Player(string name, IScore score)
        {
            Name = name;
            PlayerScore = score;
        }
        public string GetStats()
        {
            return $"{Name}'s score is {PlayerScore.CurrentScore} out of {Score.MaximumScore} with Average time of {PlayerScore.Time.ShowAverageTime()}";
        }
    }
}
