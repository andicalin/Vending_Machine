using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface ICashPaymentTerminal
    {
       float AskForMoney(float sum);
       void InvalidInput();
       void GiveBackChange(float change, Dictionary<string, int> changeDetails);
       string CancelPayment();
       void ReturnMoney(float money);
       bool ShouldCancelPayment(float money);
    }
}
