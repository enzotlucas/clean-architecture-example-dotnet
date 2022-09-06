﻿namespace Exemplo.CRUD.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
