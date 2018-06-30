using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dnc.Common.Mongo;
using Store.Services.Products.Domain;

namespace Store.Services.Products.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoRepository<Product> _repository;

        public ProductRepository(IMongoRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Product> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<IEnumerable<Product>> BrowseAsync()
            => await _repository.FindAsync(_ => true);

        public async Task AddAsync(Product product)
            => await _repository.CreateAsync(product);
    }
}