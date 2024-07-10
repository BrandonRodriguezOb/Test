using Test.Domain.Models;

namespace Test.Domain.IServices
{
    public interface IProductService
    {

        public  Task<List<Product>> getAllProducts();

        public Task<Product> getProductById(int id);

        public Task CreateProduct(Product product);

        public Task DeleteProduct(Product product);

        public Task UpdateProduct(Product product);

    }
}
