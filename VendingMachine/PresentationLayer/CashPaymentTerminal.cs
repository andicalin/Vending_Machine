using System;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase, ICashPaymentTerminal
    {
        public float AskForMoney(float sum)
        {
            Display($"You have inserted {sum} so far. Please insert more money\n", ConsoleColor.White);
            float.TryParse(Console.ReadLine(), out float value);
            return value;
        }

        public void InvalidInput()
        {
            Display("The input you inserted is invalid,try again\n", ConsoleColor.Red);
        }
        public void GiveBackChange(float change, Dictionary<string, int> changeDetails)
        {
            Console.WriteLine($"change is: {change:0}");
            foreach (var details in changeDetails)
            {
                Display($"{details.Key}: {details.Value}\n", ConsoleColor.White);
            }
        }
        public string CancelPayment()
        {
            Display("Do you wish to cancel the payment process?Yes/No\n", ConsoleColor.White);
            string userInput = Console.ReadLine();
            return (userInput == "Yes") ? "Yes" : "";
        }
        public void ReturnMoney(float money)
        {
            Display($"You have received {money}\n", ConsoleColor.White);
        }
        public bool ShouldCancelPayment(float money)
        {
            string answer = CancelPayment();
            if (answer == "Yes")
            {
                ReturnMoney(money);
                return true;
            }
            return false;
        }
    }
}
