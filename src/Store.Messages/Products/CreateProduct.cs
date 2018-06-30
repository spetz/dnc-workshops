using System;
using Dnc.Common.Commands;
using Newtonsoft.Json;

namespace Store.Messages.Products
{
    public class CreateProduct : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Category { get; }
        public decimal Price { get; }

        [JsonConstructor]
        public CreateProduct(Guid id, string name,
            string category, decimal price)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
            Category = category;
            Price = price;
        }
    }
}