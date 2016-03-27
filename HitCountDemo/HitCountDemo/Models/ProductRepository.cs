using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HitCountDemo.Models
{
    public class ProductRepository
    {
        static List<Product> db;
        static ProductRepository()
        {
            db = new List<Product>{
                new Product{ Id = 1, Name = "P1", Price = 100},
                new Product{ Id = 2, Name = "P2", Price = 100},
                new Product{ Id = 3, Name = "P3", Price = 100},
            };
        }

        public static List<Product> GetAllProduct()
        {
            return db;
        }
        public static void AddProduct(Product prod)
        {
            db.Add(prod);
        }

    }
}