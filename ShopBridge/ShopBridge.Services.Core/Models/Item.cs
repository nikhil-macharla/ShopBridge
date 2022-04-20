using ShopBridge.Services.Core.Enums;
using System;

namespace ShopBridge.Services.Core.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public string ModelNumber { get; set; }
        public string Manufacturer { get; set; }
    }
}
