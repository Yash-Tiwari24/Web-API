using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API
{
    public class DependencyService2
    {
        private readonly IOperationTransient _transient;
        private readonly IOperationScoped _scoped;
        private readonly IOperationSingleton _singleton;
        private readonly IOperationSingletonInstance _singletonInstance;

       public DependencyService2(
       IOperationTransient transientOperation,
       IOperationScoped scopedOperation,
       IOperationSingleton singletonOperation,
       IOperationSingletonInstance instanceOperation)
        {
            _transient = transientOperation;
            _scoped = scopedOperation;
            _singleton = singletonOperation;
            _singletonInstance = instanceOperation;
        }
        public void Write()
        {
            Console.WriteLine();
            Console.WriteLine("From DependencyService2");
            Console.WriteLine($"Transient - {_transient.OperationId}");
            Console.WriteLine($"Scoped - {_scoped.OperationId}");
            Console.WriteLine($"Singleton - {_singleton.OperationId}");
            Console.WriteLine($"Singleton Instance - {_singletonInstance.OperationId}");

        }
    }
}
