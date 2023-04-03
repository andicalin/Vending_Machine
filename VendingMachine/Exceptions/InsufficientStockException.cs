using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InsufficientStockException : Exception
    {

        internal InsufficientStockException() : base(Message) 
        {
        }

        private const string Message = "Product out of stock";
    }
}
