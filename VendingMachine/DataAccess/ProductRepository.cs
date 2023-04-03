using RemoteLearning.VendingMachine.ProductModel;
using System.Collections.Generic;
using System.Linq;

namespace RemoteLearning.VendingMachine.DataAccess

{
    internal class ProductRepository : IProductRepository
    {
        private readonly List<Product> allProducts = new List<Product>{ new Product() { Id = 1, Name = "Milka ", Price = 6, Quantity = 10 },
                                          new Product() { Id = 2, Name = "Haribo ", Price = 8, Quantity = 1 },
                                          new Product() { Id = 3, Name = "Sprite ", Price = 4, Quantity = 5},
                                          new Product() { Id = 4, Name = "Skittles ", Price = 2, Quantity = 9},
                                          new Product() { Id = 5, Name = "Dorna ", Price = 2, Quantity = 18},
                                         };
        public ProductRepository()
        {
           
        }

        public IEnumerable<Product> GetAll()
        {
            return allProducts;
        }

        
        public Product GetById(int id)
        {
            return allProducts.FirstOrDefault(x => x.Id == id);

        }

        public void UpdateProd(Product product)
        {
            /*product.Quantity -= 1;*/
        }
    }
}
    