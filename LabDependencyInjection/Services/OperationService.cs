using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab002_DependencyInjection.Services
{
    public class OperationService : IOperationScoped, IOperationSingleton, IOperationTransient
    {
        public string OperationId { get; } = Guid.NewGuid().ToString()[^4..];

    }
}
