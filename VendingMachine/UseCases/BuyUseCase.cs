using System;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.ProductModel;
using RemoteLearning.VendingMachine.Exceptions;
using Nagarro.VendingMachine.Authentication;

namespace RemoteLearning.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;

        private readonly IProductRepository productRepository;

        private readonly IAuthenticationService authenticationService;

        private readonly IPaymentUseCase paymentUseCase;

        public string Name => "buy";

        public string Description => "From here you can buy products";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(IBuyView buyView, IProductRepository productRepository, IAuthenticationService authenticationService, IPaymentUseCase paymentUseCase)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
        }

        public static void DecrementStock(Product product)
        {
            
            product.Quantity -= 1;
        }

        public void Execute()
        {

            int productId = buyView.RequestId();
            Product product = productRepository.GetById(productId) ?? throw new InvalidProductIdException(productId);
            if (product.Quantity < 1) throw new InsufficientStockException();
            while (true)
            {
                if (buyView.ConfirmPay())
                {
                    break;
                }
                else
                {
                    return;
                }
              
            }
            paymentUseCase.Execute(product.Price);
            DecrementStock(product);
            productRepository.UpdateProd(product);
            buyView.DispensProduct(product);

        }
    }
}
