using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace HumanCalculator
{
     public class TimeFactory : ITimeFactory
    {
        private IServiceProvider serviceProvider;
        public TimeFactory(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }
        public ITime Create()
        {
            return serviceProvider.GetRequiredService<ITime>(); 
        }
    }
}
