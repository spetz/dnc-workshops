using System;
using Dnc.Common.Events;
using Newtonsoft.Json;

namespace Store.Messages.Products
{
    public class ProductCreated : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Category { get; }
        public decimal Price { get; }

        [JsonConstructor]
        public ProductCreated(Guid id, string name,
            string category, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }        
    }
}