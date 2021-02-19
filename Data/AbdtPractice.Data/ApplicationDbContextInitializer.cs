using System.Linq;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using AbdtPractice.Identity.Entities;
using Extensions.Hosting.AsyncInitialization;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AbdtPractice.Data
{
    [UsedImplicitly]
    public class ApplicationDbContextInitializer : IAsyncInitializer
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitializer(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
        }

        private async Task SeedEverything()
        {
            var categories = new []
            {
                new Category("C1"),
                new Category("C2"),
                new Category("C3")
            };
            
            if (!_context.Categories.Any())
            {
                await _context.Categories.AddRangeAsync(categories);
            }
            
            
            if (!_context.Products.Any())
            {
                await _context.Products.AddAsync(new Product(categories[1], "Product1", 100, 0));
                await _context.Products.AddAsync(new Product(categories[1], "Product2", 500, 0));
                await _context.Products.AddAsync(new Product(categories[2], "Product3", 100500, 0));
                await _context.Products.AddAsync(new Product(categories[2], "Bestseller1", 200, 0) {PurchaseCount = 11});
                await _context.Products.AddAsync(new Product(categories[1], "Bestseller2", 300, 0) {PurchaseCount = 11});
                await _context.Products.AddAsync(new Product(categories[1], "Sale1", 400, 10));
                await _context.Products.AddAsync(new Product(categories[1], "Sale2", 500, 20));
                await _context.SaveChangesAsync();
            }
        }

        public async Task InitializeAsync()
        {
            await _context.Database.MigrateAsync();
            await SeedEverything();
        }
    }
}