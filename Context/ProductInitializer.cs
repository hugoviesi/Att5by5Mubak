using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    class ProductInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
       protected override void Seed(ProductContext context)
        {
            var products = new List<Product>
            {
                new Product {Description = "Memoria ram", Brand = "HyperX", Model = "8GB Fury", UnitaryPrice = 250.50M, Category = new Category { Description = "Hardware"}},
                new Product {Description = "Notebook", Brand = "Dell", Model = "Ultrabook i7", UnitaryPrice = 5000.50M, Category = new Category { Description = "Notebook"}}
            };

            products.ForEach(product => context.Products.Add(product));
            context.SaveChanges();
        }
    }
}