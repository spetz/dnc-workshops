using System;
using System.Threading.Tasks;
using Dnc.Common;
using Dnc.Common.Events;
using Store.Messages.Products;

namespace Store.Api.Handlers
{
    public class ProductCreatedHandler : IEventHandler<ProductCreated>
    {
        public async Task HandleAsync(ProductCreated @event, ICorrelationContext context)
        {
            Console.WriteLine($"Product created: {@event.Name}.");
            await Task.CompletedTask;
        }
    }
}