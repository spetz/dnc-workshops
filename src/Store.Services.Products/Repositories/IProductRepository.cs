using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Services.Products.Domain;

namespace Store.Services.Products.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(Guid id);
        Task<IEnumerable<Product>> BrowseAsync();
        Task AddAsync(Product product);
    }
}