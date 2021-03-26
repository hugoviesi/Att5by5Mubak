using Model;
using System.Collections.Generic;
using System.Data.Entity;


namespace Context
{
    public class ItemProductInitializer : DropCreateDatabaseIfModelChanges<ItemProductContext>
    {
        protected override void Seed(ItemProductContext context)
        {
            var items = new List<ItemProduct>
            {
                new ItemProduct
                {
                    Product = new Product
                    {
                        Description = "Notebook",
                        Model = "2018",
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

                new ItemProduct
                {
                    Product = new Product
                    {
                        Description = "Placa de Vídeo",
                        Model = "2078",
                        Brand = "NVIDIA",
                        UnitaryPrice = 7000,
                        Category = new Category
                        {
                            Description = "Hardware"
                        }
                    },
                    UnitaryValue = 7000,
                    Amount = 2,
                    TotalValue = 14000
                }
            };


            items.ForEach(i => context.ItemsProducts.Add(i));
            context.SaveChanges();
        }
    }
}
