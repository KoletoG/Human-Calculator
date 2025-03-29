using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
    public interface ITime
    {
        byte[] Times { get; }
        byte AverageTime { get; }
        void CalcAverageTime();
        string ShowAverageTime();
    }
    interface IScore
    {
        ITime Time { get; }
        byte CurrentScore { get; }
        void AddTime(byte seconds);
        void AddScore();
    }
    interface IPlayer
    {
        char[] Name { get; }
        IScore PlayerScore { get; }
        string GetStats();
    }
    internal class Interfaces
    {
    }
}
