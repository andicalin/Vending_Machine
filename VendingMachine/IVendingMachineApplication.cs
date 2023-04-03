using System.Collections.Generic;

namespace RemoteLearning.VendingMachine
{
    internal interface IVendingMachineApplication
    {
       void Run();
       List<IUseCase> GetExecutableUseCases();
    }
}
