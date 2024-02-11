namespace KentuckyProudSeedCo.Data.Entities
{
    public class Fact
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TermId { get; set; }   
        public string Definition { get; set; } = null!;
    }
}
