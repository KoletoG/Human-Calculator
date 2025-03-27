using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCalculator
{
    public class MaximumScoreExceedingException : Exception
    {
        public MaximumScoreExceedingException(byte currentScore) : base($"Your score {currentScore+1} cannot be more than the maximum score {Score.MaximumScore}")
        {

        }
    }
}
