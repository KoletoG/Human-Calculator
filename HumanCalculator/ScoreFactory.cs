using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace HumanCalculator
{
    internal class ScoreFactory : IScoreFactory
    {
        private IServiceProvider serviceProvider;
        public ScoreFactory(IServiceProvider service)
        {
            serviceProvider = service;
        }
        /// <summary>
        /// Creates a new instance of IScore
        /// </summary>
        /// <returns>A new instance of IScore</returns>
        public IScore Create()
        {
            return serviceProvider.GetRequiredService<IScore>();
        }
    }
}
