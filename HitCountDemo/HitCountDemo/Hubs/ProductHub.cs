using HitCountDemo.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HitCountDemo.Hubs
{
    public class ProductHub : Hub
    {
        public void LoadProduct()
        {
            Clients.All.getAll(ProductRepository.GetAllProduct());
        }
        public void AddProduct(Product prod)
        {
            ProductRepository.AddProduct(prod);
            Clients.All.getAll(ProductRepository.GetAllProduct());
        }

        public void CreateProduct(Product prod)
        {
            ProductRepository.AddProduct(prod);
            Clients.Others.getAll(ProductRepository.GetAllProduct());
            Clients.Caller.success(prod);
        }
    }
}