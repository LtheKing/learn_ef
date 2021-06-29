using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Phones.Any())
            {
                return; //DB Has been seeded
            }

            var phones = new Phone[]
            {
                new Phone
                {
                    CategoryID = 1,
                    Merk = "Xiaomi POCO X3 Pro",
                    Price = 3450000
                }
            };

            await context.Phones.AddRangeAsync(phones);

            await context.SaveChangesAsync();

            var category = new Category {
                CategoryName = "Under 5 Million IDR"
            };

            await context.Categories.AddAsync(category);

            await context.SaveChangesAsync();

            var cust = new Customer 
            {
                Name = "Leonaldi Nata Gunawan",
                Phone = "089795348634",
                Email = "leonalding77@gmail.com",
                Address = "jalan vinca i block g8 no 32"
            };

            await context.Customers.AddAsync(cust);

            await context.SaveChangesAsync();

            var trans = new Transaction
            {
                CustomerID = 1,
                TransactionDate = DateTime.Now
            };

            await context.Transactions.AddAsync(trans);
            await context.SaveChangesAsync();
        }
    }
}