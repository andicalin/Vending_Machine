using System;
using System.Collections.Generic;
using RemoteLearning.VendingMachine.PresentationLayer;

namespace RemoteLearning.VendingMachine
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private readonly IEnumerable<IUseCase> useCases;
        private readonly IMainView mainView;

        public VendingMachineApplication(IEnumerable<IUseCase> useCases, IMainView mainView)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                List<IUseCase> availableUseCases = GetExecutableUseCases();

                try
                {

                    IUseCase useCase = mainView.ChooseCommand(availableUseCases);
                    useCase.Execute();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex);
                }
                
            }
        }

        public List<IUseCase> GetExecutableUseCases()
        {
            List<IUseCase> executableUseCases = new List<IUseCase>();

            foreach (IUseCase useCase in useCases)
            {
                if (useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }

            return executableUseCases;
        }
    }
}