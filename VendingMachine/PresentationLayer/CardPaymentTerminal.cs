using System;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase, ICardPaymentTerminal
    {
        public string AskForCardNumber()
        {
            Display($"Insert your card number: \n", ConsoleColor.White);
            return Console.ReadLine();
        }
        public void InvalidCardNumber()
        {
            Display("The card number is not valid \n", ConsoleColor.Red);
        }
    }
}
