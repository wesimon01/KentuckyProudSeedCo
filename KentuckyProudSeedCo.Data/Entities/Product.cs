using KentuckyProudSeedCo.Data.Interface;

namespace KentuckyProudSeedCo.Data.Entities
{
    public abstract class Product
    {
        public int Id { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Categorization { get; set; }
        public string? Description { get; set; }
        public string? ProductDetails { get; set; }  
        public string? ShippingInformation { get; set; }
        public bool OnlineOnly { get; set; }
        public bool OnSale { get; set; }
        public bool InStock { get; set; }
        public bool KyProudExclusive { get; set; }
        public bool DevelopedByKyProud { get; set; }
        public ICollection<Fact>? QuickFacts { get; set; }
    }
}
