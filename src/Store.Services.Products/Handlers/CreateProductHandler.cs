using System;
using System.Threading.Tasks;
using Dnc.Common;
using Dnc.Common.Commands;
using Dnc.Common.RabbitMq;
using Store.Messages.Products;

namespace Store.Services.Products.Handlers
{
    public class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IBusPublisher _busPublisher;

        public CreateProductHandler(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(CreateProduct command, ICorrelationContext context)
        {
            Console.WriteLine($"Create product: {command.Name}.");
            await _busPublisher.PublishEventAsync(new ProductCreated(command.Id,
                command.Name, command.Category, command.Price), context);
        }
    }
}