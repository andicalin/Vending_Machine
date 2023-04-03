using RemoteLearning.VendingMachine.ProductModel;
using System.Collections.Generic;


namespace RemoteLearning.VendingMachine.DataAccess
{
    internal interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetById (int id);
        public void UpdateProd(Product product);
    }
}
