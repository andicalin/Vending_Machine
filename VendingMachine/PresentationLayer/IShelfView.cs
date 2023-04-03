using RemoteLearning.VendingMachine.ProductModel;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface IShelfView
    {
        void DisplayProducts(IEnumerable<Product> products);
        bool HasProducts(IEnumerable<Product> products);
    }
}
