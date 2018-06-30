using System;
using System.Threading.Tasks;
using Dnc.Common;
using Dnc.Common.Commands;
using Dnc.Common.RabbitMq;
using Store.Messages.Products;
using Store.Services.Products.Domain;
using Store.Services.Products.Repositories;

namespace Store.Services.Products.Handlers
{
    public class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IBusPublisher busPublisher,
            IProductRepository productRepository)
        {
            _busPublisher = busPublisher;
            _productRepository = productRepository;
        }

        public async Task HandleAsync(CreateProduct command, ICorrelationContext context)
        {
            Console.WriteLine($"Create product: {command.Name}.");
            await _productRepository.AddAsync(new Product(command.Id,
                command.Name, command.Category, command.Price));
            await _busPublisher.PublishEventAsync(new ProductCreated(command.Id,
                command.Name, command.Category, command.Price), context);
        }
    }
}