﻿using KentuckyProudSeedCo.Data.Interface;

namespace KentuckyProudSeedCo.Data.Entities
{
    public partial class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; } = null!;
    }
}
