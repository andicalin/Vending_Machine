using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface IMainView
    {
        IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
        void DisplayApplicationHeader();
        
    }
}
