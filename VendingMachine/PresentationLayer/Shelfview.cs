using RemoteLearning.VendingMachine.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class Shelfview : DisplayBase, IShelfView
    {
        public void DisplayProducts(IEnumerable<Product>products)
        {
            if (HasProducts(products)) 
            {
                Console.WriteLine("There are no more products left");    
            }
            else
            {
                foreach (Product product in products) 
                {
                    Console.WriteLine();
                    Display($"ID:{product.Id} " +
                             $"Name:{product.Name}" +
                             $"Price:{product.Price} " +
                             $"Quantity:{product.Quantity}", 
                             ConsoleColor.Yellow);
                }
            }

        }



        public bool HasProducts(IEnumerable<Product> products)
        {
            if (products != null && (!products.Any()))
            {
                return true;
            }
            return false;
        }

    }
}
