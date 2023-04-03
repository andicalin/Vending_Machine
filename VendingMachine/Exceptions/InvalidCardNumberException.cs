using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InvalidCardNumberException : Exception
    {
        private const string DefaultMessage = "The card number you insterted is invalid";

        public InvalidCardNumberException()
            : base(DefaultMessage)
        {
        }
    }
}
