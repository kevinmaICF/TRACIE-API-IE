using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.factorypattern.Interface
{
    public interface IServiceFactory<T> where T : class
    {
        T Build();

    }
}
