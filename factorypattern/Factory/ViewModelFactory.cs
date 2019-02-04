using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRACIE_API_IE.factorypattern.Interface;
using TRACIE_API_IE.IEBL;

namespace TRACIE_API_AC.factorypattern.Factory
{
    public class ViewModelFactory : IViewModelFactory
    {
        public Dictionary<Type, Func<BaseViewModel>> _factories { get; set; } = new Dictionary<Type, Func<BaseViewModel>>();
        //private readonly Dictionary<Type, Func<BaseViewModel>> _factories;

        public ViewModelFactory()
        {

        }

        public T Create<T>() where T : BaseViewModel
        {
            return _factories[typeof(T)]() as T;
        }

        public List<T> Createlist<T>() where T : BaseViewModel
        {

            return _factories[typeof(T)]() as List<T>;
        }
    }
}
