using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRACIE_API_IE.IEBL;

namespace TRACIE_API_IE.factorypattern.Interface
{
    public interface IViewModelFactory
    {
        T Create<T>() where T : BaseViewModel;
        List<T> Createlist<T>() where T : BaseViewModel;
    }
}
