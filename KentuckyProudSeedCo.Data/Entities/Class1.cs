namespace KentuckyProudSeedCo.Data.Entities
{
    public class Vegetable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Variety> Varities { get; set; } = null!;
    }
}
