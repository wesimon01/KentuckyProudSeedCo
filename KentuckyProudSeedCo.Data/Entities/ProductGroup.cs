using KentuckyProudSeedCo.Data.Interface;

namespace KentuckyProudSeedCo.Data.Entities
{
    public partial class ProductGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductCategory> Products { get; set; } = null!;
    }
}
