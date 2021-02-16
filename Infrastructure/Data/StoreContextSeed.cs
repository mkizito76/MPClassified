using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                   var dataToSeed = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var data = JsonSerializer.Deserialize<List<ProductBrand>>(dataToSeed);
                    data.ForEach(x => context.ProductBrands.Add(x));
                    await context.SaveChangesAsync();
                }

                if(!context.ProductTypes.Any())
                {
                    var dataToSeed = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var data = JsonSerializer.Deserialize<List<ProductType>>(dataToSeed);
                    data.ForEach(x => context.ProductTypes.Add(x));
                    await context.SaveChangesAsync();
                }

                if(!context.Products.Any())
                {
                    var dataToSeed = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var data = JsonSerializer.Deserialize<List<Product>>(dataToSeed);
                    data.ForEach(x => context.Products.Add(x));
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}