using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanCalculator.Models;

namespace HumanCalculator.Exceptions
{
    public class MaximumScoreExceedingException : Exception
    {
        public MaximumScoreExceedingException(int currentScore) : base($"Your score {currentScore+1} cannot be more than the maximum score {Score.MaximumScore}")
        {

        }
    }
}
