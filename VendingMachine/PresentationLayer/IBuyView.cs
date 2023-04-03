using RemoteLearning.VendingMachine.PaymentModel;
using RemoteLearning.VendingMachine.ProductModel;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface IBuyView
    {
        public int RequestId();
        public void DispensProduct(Product product);
        public bool ConfirmPay();
        public void Invalid();
        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
