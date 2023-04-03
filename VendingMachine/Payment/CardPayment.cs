using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.Exceptions;
using System;

namespace RemoteLearning.VendingMachine.Payment
{
    internal class CardPayment : IPaymentAlgorithm
    {
        public string Name => "card";

        private readonly ICardPaymentTerminal cardPaymentTerminl;
        public CardPayment(ICardPaymentTerminal cardPaymentTerminal) 
        {
            this.cardPaymentTerminl = cardPaymentTerminal ?? throw new ArgumentNullException(nameof(cardPaymentTerminal)); ;
        }

        // using Luhn's algorithm to verify if a card number is valid or not
        private bool IsValid(string cardNo)
        {
            int nDigits = cardNo.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {

                int d = cardNo[i] - '0';

                if (isSecond == true)
                    d = d * 2;
                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return nSum % 10 == 0;
        }

        public void Run(float price)
        {
            string cardNO = cardPaymentTerminl.AskForCardNumber();
            if (!IsValid(cardNO))
            {
                cardPaymentTerminl.InvalidCardNumber();
                throw new InvalidCardNumberException();
            }
        }

    }
}
