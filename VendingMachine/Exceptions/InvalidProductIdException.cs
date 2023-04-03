using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InvalidProductIdException : Exception
    {
        public InvalidProductIdException(int id) 
            : base(GetMessage(id)) 
        {
        }

        private static string GetMessage(int id)
        {
            return $"{id} is not valid";
        } 
    }
}
