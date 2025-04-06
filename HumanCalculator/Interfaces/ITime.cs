using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator.Interfaces
{
    public interface ITime
    {
        int[] Times { get; }
        int AverageTime { get; }
        void CalcAverageTime();
        string ShowAverageTime();
        void SetTimeArray();
    }
}
