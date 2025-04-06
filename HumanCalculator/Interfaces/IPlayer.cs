using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        IScore PlayerScore { get; }
        string GetStats();
    }
}
