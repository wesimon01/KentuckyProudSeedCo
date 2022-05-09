namespace KentuckyProudSeedCo.Data.Entities
{
    public class ProductSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
