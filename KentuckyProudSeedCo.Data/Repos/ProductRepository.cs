using KentuckyProudSeedCo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentuckyProudSeedCo.Data.Repos
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository genericRepo;

        public ProductRepository(IGenericRepository genericRepo)
        {
            this.genericRepo = genericRepo;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await genericRepo.FindAll<Product>();
        }

        public async Task<Product?> GetProductAsync(int productId)
        {
            return await genericRepo.FindById<Product>(productId);
        }

        public async Task AddProduct(Product product)
        {
            await genericRepo.Add(product); 
        }

        public void DeleteProduct(Product product)
        {
            genericRepo.Delete(product);
        }


    }
}
