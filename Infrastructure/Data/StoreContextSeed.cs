using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Core.Entities.OrderAggregate;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                context.Database.OpenConnection();
                if (!context.ProductBrands.Any())
                {
                    var dataToSeed = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var data = JsonSerializer.Deserialize<List<ProductBrand>>(dataToSeed);
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductBrands ON"); // To set specific Ids
                    data.ForEach(x => context.ProductBrands.Add(x));
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductBrands OFF");
                }

                if (!context.ProductTypes.Any())
                {
                    var dataToSeed = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var data = JsonSerializer.Deserialize<List<ProductType>>(dataToSeed);
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductTypes ON");
                    data.ForEach(x => context.ProductTypes.Add(x));
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductTypes OFF");
                }

                if (!context.DeliveryMethods.Any())
                {
                    var dataToSeed = File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");
                    var data = JsonSerializer.Deserialize<List<DeliveryMethod>>(dataToSeed);
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DeliveryMethods ON");
                    data.ForEach(x => context.DeliveryMethods.Add(x));
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DeliveryMethods OFF");
                }

                if (!context.Products.Any())
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
            finally
            {
                context.Database.CloseConnection();
            }
        }
    }
}