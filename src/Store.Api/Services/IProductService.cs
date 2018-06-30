using System;
using System.Threading.Tasks;
using RestEase;

namespace Store.Api.Services
{
    public interface IProductService
    {
        [Get("products/{id}")]
        [AllowAnyStatusCode]
        Task<object> GetAsync([Path]Guid id);

        [Get("products")]
        [AllowAnyStatusCode]
        Task<object> BrowseAsync();
    }
}