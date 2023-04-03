using RemoteLearning.VendingMachine.PaymentModel;
using RemoteLearning.VendingMachine.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {
        public int RequestId()
        {   
            while(true)
            {
                Console.WriteLine();
                Display("Choose Id of the product you want: ", ConsoleColor.Yellow);
                if (!int.TryParse(Console.ReadLine(), out int ID))
                    {
                    Invalid();
                    continue;
                    }
                return ID;
            }
           
        }

        public void DispensProduct (Product product)
        {
            Console.WriteLine();
            DisplayLine(product.Name + "dispensed", ConsoleColor.Yellow);
        }

        public bool ConfirmPay()
        {
            Display($"Have you selected the correct item (Yes/No) ", ConsoleColor.Yellow);
            string answer = Console.ReadLine();
            if (answer == "Yes")
            {
                return true;
            }
            else if (answer == "No")
            {
                return false;
            }
            else
            {
                Invalid();
                return false;

            }
        }

        public void Invalid()
        {
            Display("Input is invalid.", ConsoleColor.White);
            Console.WriteLine();
        }

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            Display("card or cash?: ", ConsoleColor.White);
            
            while (true)
            {
                string answer = Console.ReadLine().ToLower();
                if (!paymentMethods.Any(x => x.Name.ToLower() == answer))
                {
                    Display("Incorrect input, try again", ConsoleColor.White);
                    Console.WriteLine();
                    continue;
                }
                foreach (PaymentMethod paymentMethod in paymentMethods)
                {
                    if (paymentMethod.Name.Equals(answer.ToLower()))
                        return paymentMethod.Id;
                }
            }

        }
    }
}
