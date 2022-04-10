namespace KentuckyProudSeedCo.Data.Entities
{
    public class Variety
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LatinName { get; set; }
        public string? Breeder { get; set; }
        public string? Details { get; set; }
        public string? Description { get; set; }
        public string? GerminationGuideImageUrl { get; set; }
        public Fact? DaysToMaturity { get; set; }
        public Fact? DiseaseResistanceCodes { get; set; }
        public Fact? LifeCycle { get; set; }
        public Fact? HybridStatus { get; set; }
        public Fact? ProductFeatures { get; set; }
        public bool InStock { get; set; }
    }
}
