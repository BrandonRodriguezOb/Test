using Microsoft.EntityFrameworkCore;
using Test.Domain.IRepositories;
using Test.Domain.Models;

namespace Test.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDBContext dbContext;

        public ProductRepository(ApplicationDBContext _dBContext)
        {
            dbContext =   _dBContext;
        }

        public async Task<List<Product>> getAllProducts()
        {
            List<Product> products = new List<Product>();
            products = await dbContext.Product.ToListAsync();
            return products;

        }

        public async Task CreateProduct(Product product)
        {
           await dbContext.Product.AddAsync(product);
           await dbContext.SaveChangesAsync();

        }
            

        public async Task<Product> getProductById(int id)
        {
            var product = await dbContext.Product.Where(x=> x.Id == id).FirstOrDefaultAsync();
            return product;         
        }

        public async Task DeleteProduct(Product product)
        {            
            dbContext.Product.Remove(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {

            dbContext.Product.Update(product);
            await dbContext.SaveChangesAsync();

        }
    }
}
