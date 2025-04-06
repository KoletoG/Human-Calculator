using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator.Interfaces
{
    public interface IScore
    {
        ITime Time { get; }
        int CurrentScore { get; }
        void AddTime(int seconds);
        void AddScore();
    }
}
