namespace KentuckyProudSeedCo.Data.Entities
{
    public partial class PlantProduct : Product
    {
        public string? GrowingInformation { get; set; }
        public bool IsOrganic { get; set; }
    }
}
