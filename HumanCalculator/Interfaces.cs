using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
    public interface ITime
    {
        List<double> Times { get; }
        double AverageTime { get; }
        void CalcAverageTime();
        string ShowAverageTime();
    }
    interface IScore
    {
        ITime Time { get; }
        byte CurrentScore { get; set; }
        void AddTime(double seconds);
        void AddScore();
    }
    interface IPlayer
    {
        string Name { get; }
        IScore PlayerScore { get; }
        string GetStats();
    }
    internal class Interfaces
    {
    }
}
