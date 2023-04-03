using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class BuyCancelException : Exception
    {
        private const string DefaultMessage = "The buy operation has been cancelled";

        public BuyCancelException()
            : base(DefaultMessage)
        {
        }
    }
}
