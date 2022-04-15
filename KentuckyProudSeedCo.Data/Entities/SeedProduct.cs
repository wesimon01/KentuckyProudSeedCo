namespace KentuckyProudSeedCo.Data.Entities
{
    public class SeedProduct : Product
    {
        public string? GerminationGuideImageUrl { get; set; }
        public string? GrowingInformation { get; set; }
        public bool IsOrganic { get; set; }        
    }      

    public class PlantProduct : Product
    {
        public bool IsOrganic { get; set; }
    }
}
