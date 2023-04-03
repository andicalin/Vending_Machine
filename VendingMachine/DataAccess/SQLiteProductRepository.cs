using System;
using System.Collections.Generic;
using System.Data.SQLite;
using RemoteLearning.VendingMachine.ProductModel;

namespace RemoteLearning.VendingMachine.DataAccess
{
    internal class SQLiteProductRepository : IProductRepository, IDisposable
    {
        public SQLiteConnection myConnection;
        public SQLiteProductRepository(string connectionString)
        {
            myConnection = new SQLiteConnection(connectionString);
            myConnection.Open();
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new();
            string querry = "SELECT * FROM Products";
            using (SQLiteCommand command = new(querry, myConnection))
            {
                using var reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        products.Add(new Product()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetInt32(2),
                            Quantity = reader.GetInt32(3)
                        });
                    }
                }
            }
            return products;
        }

        public Product GetById(int id)
        {
            string querry = $"SELECT * FROM Products where Id={id}";
            Product product = new Product();
            using (SQLiteCommand command = new(querry, myConnection))
            {
                using var reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.Price = reader.GetInt32(2);
                        product.Quantity = reader.GetInt32(3);
                    }
                    return product;
                }
            }
        }

        public void UpdateProd(Product product)
        {
            using (SQLiteCommand command = new SQLiteCommand(myConnection))
            {
                command.CommandText = string.Format("UPDATE Products SET Name='{1}', Price={2}, Quantity={3} WHERE Id={0}", product.Id, product.Name, product.Price, product.Quantity);
                command.ExecuteNonQuery();
            }
        }



        public void Dispose()
        {
            myConnection.Close();
            myConnection.Dispose();
        }
    }
}
