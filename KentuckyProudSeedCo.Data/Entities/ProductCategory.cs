namespace KentuckyProudSeedCo.Data.Entities
{
    public class ProductCategory : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = null!;
    }
}
