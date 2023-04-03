using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.Payment
{
    internal class CashPayment : IPaymentAlgorithm
    {
        private List<float> values = new List<float> { 1, 5, 10, 50, 100, 200, 500 };
        private List<string> money = new List<string> { "1 leu", "5 lei", "10 lei", "50 lei", "100 lei", "200 lei", "500 lei" };

        public string Name => "cash";

        private readonly ICashPaymentTerminal cashPaymentTerminal;

        public CashPayment(ICashPaymentTerminal cashPaymentTerminal)
        {
            this.cashPaymentTerminal = cashPaymentTerminal ?? throw new ArgumentNullException(nameof(cashPaymentTerminal)); ;
        }

        private Dictionary<string, int> CalculateChange(float change)
        {
            Dictionary<string, int> changeDetails = new();
            for (int i = money.Count - 1; i >= 0; i--)
            {
                int moneyCount = (int)(change / values[i]);
                if (moneyCount != 0) changeDetails.Add(money[i], moneyCount);
                change %= values[i];
            }
            return changeDetails;
        }
        public void Run(float price)
        {
            
            float totalInsertedValue = 0;
            while (totalInsertedValue < price)
            {
                float insertedValue = cashPaymentTerminal.AskForMoney(totalInsertedValue);
                if (!values.Contains(insertedValue))
                {
                    cashPaymentTerminal.InvalidInput();
                    continue;
                }
                totalInsertedValue += insertedValue;
            }
            if (cashPaymentTerminal.ShouldCancelPayment(totalInsertedValue))
                throw new BuyCancelException();

            float change = totalInsertedValue - price;
            cashPaymentTerminal.GiveBackChange(change, CalculateChange(change));
        }
    }
}
