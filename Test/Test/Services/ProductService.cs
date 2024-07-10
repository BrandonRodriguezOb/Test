using Test.Domain.IRepositories;
using Test.Domain.IServices;
using Test.Domain.Models;

namespace Test.Services
{
    public class ProductService: IProductService
    {

        private readonly IProductRepository repository;

        public ProductService( IProductRepository _repo) {
            repository = _repo;
        }


        public async Task<List<Product>> getAllProducts()
        {
            return await repository.getAllProducts();
        }


        public async Task CreateProduct(Product product)
        {           
            await repository.CreateProduct(product);
        }

      
        public async Task<Product> getProductById(int id)
        {
            return await repository.getProductById(id);
        }

        public async Task UpdateProduct(Product product)
        {
           await repository.UpdateProduct(product);
        }

        public async Task DeleteProduct(Product product)
        {
            await repository.DeleteProduct(product);
        }
    }
}
