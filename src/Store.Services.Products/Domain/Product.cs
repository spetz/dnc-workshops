using System;
using Dnc.Common;

namespace Store.Services.Products.Domain
{
    public class Product : IIdentifiable
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }

        private Product()
        {
        }

        public Product(Guid id, string name,
            string category, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            SetPrice(price);
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Invalid price.",
                    nameof(price));
            }
            Price = price;
        }
    }
}