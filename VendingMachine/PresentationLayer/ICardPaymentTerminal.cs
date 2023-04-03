namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface ICardPaymentTerminal
    {
       string AskForCardNumber();
       void InvalidCardNumber();
    }
}
