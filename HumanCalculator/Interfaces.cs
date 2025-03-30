using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
    public interface ITime
    {
        int[] Times { get; }
        int AverageTime { get; }
        void CalcAverageTime();
        string ShowAverageTime();
    }
    interface IScore
    {
        ITime Time { get; }
        int CurrentScore { get; }
        void AddTime(int seconds);
        void AddScore();
    }
    interface IPlayer
    {
        string Name { get; }
        IScore PlayerScore { get; }
        string GetStats();
    }
    interface IGameService
    {
        void RepeatGame();
        IScore StartGame();
    }
    internal class Interfaces
    {
    }
}
