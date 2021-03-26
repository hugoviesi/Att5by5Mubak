using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Context
{
    public class SaleInitializer : DropCreateDatabaseIfModelChanges<SaleContext>
    {
        /*protected override void Seed(SaleContext context)
        {
            var sales = new List<Sale>
            {
                new Sale{
                    Payment = new Pix{ Installments = 1, KeyType = "CPF", KeyValue = "98495198941"},
                    Items = new List<ItemProduct>
                    {
                        new ItemProduct
                        {
                            Product = new Product{
                                Description = "Placa de vídeo",
                                Model = "NVIDIA",
                                Brand = "ASUS",
                                UnitaryPrice = 500,
                                Category = new Category
                                {
                                    Description = "Hardware"
                                }
                            },  
                            UnitaryValue = 15,
                            Amount = 2,
                            TotalValue = 30
                        },
                    },
                    Costumer = "User",
                    TotalValue = 10,
                    DateSale = DateTime.Now

                },
                new Sale{
                    Payment = new CreditCard{ Number = "1871951984", Cardholder = "IRWING TESTONE", CVV = "253", ExpirationDate = DateTime.Parse("10/12/2028"), Installments = 5 },
                    Items = new List<ItemProduct>
                    {
                        new ItemProduct
                        {
                            Product = new Product{
                                Description = "Notebook",
                                Model = "maizomeno",
                                Brand = "Dell",
                                UnitaryPrice = 5000,
                                Category = new Category
                                {
                                    Description = "Notebook"
                                }
                            },
                            UnitaryValue = 5000,
                            Amount = 1,
                            TotalValue = 5000
                        },
                    },
                    Costumer = "User",
                    TotalValue = 10,
                    DateSale = DateTime.Now
                },
            };

            sales.ForEach(s => context.Sales.Add(s));
            context.SaveChanges();
        }*/
    }
}
