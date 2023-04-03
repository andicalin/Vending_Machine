using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.ProductModel;
using System;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly IShelfView shelfview;

        private readonly IProductRepository productRepository;

        public string Name => "watchProducts";

        public string Description => "Here you can see all the products";

        public bool CanExecute => true;

        public LookUseCase (IShelfView shelfview, IProductRepository productRepository)
        {
            this.shelfview = shelfview ?? throw new ArgumentNullException(nameof(shelfview));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public IEnumerable<Product> InStockProducts(IEnumerable<Product> products)
        {
            List<Product> isInStock = new List<Product>();
            foreach (Product product in products)
            {
                if (product.Quantity != 0)
                {
                    isInStock.Add(product);
                }
            }
            return isInStock;
        }

        public void Execute ()
        {
            IEnumerable<Product> productsInStock =  InStockProducts(productRepository.GetAll());
            shelfview.DisplayProducts(productsInStock);
        }
    }
}
