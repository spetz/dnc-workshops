using System;
using System.Threading.Tasks;
using Dnc.Common;
using Dnc.Common.Commands;
using Store.Messages.Products;

namespace Store.Services.Products.Handlers
{
    public class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        public async Task HandleAsync(CreateProduct command, ICorrelationContext context)
        {
            Console.WriteLine($"Create product: {command.Name}.");
            await Task.CompletedTask;
        }
    }
}