using RemoteLearning.VendingMachine.Payment;
using RemoteLearning.VendingMachine.PaymentModel;
using RemoteLearning.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteLearning.VendingMachine.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private readonly IEnumerable<IPaymentAlgorithm> paymentAlgorithms;
        private readonly IBuyView buyView;


        public PaymentUseCase(IBuyView buyView, IEnumerable<IPaymentAlgorithm> paymentAlgorithms)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentAlgorithms = paymentAlgorithms ?? throw new ArgumentNullException(nameof(paymentAlgorithms));
        }
        public void Execute(float price)
        {

            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
            int i = 0;
            foreach (var paymentAlgorithm in paymentAlgorithms)
            {
                paymentMethods.Add(new PaymentMethod() { Name = paymentAlgorithm.Name, Id = i });
                i++;
            }
            int paymentMethodIndex = buyView.AskForPaymentMethod(paymentMethods);
            paymentAlgorithms.ElementAt(paymentMethodIndex).Run(price);
        }


    }
}

