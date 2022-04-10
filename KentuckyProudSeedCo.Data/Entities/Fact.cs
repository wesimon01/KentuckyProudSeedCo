using System.ComponentModel.DataAnnotations.Schema;

namespace KentuckyProudSeedCo.Data.Entities
{
    public class Fact
    {
        public int Id { get; set; }
        
        [ForeignKey("VarietyId")]
        public int VarietyId { get; set; }
        public string? Name { get; set; }   
        public string? Value { get; set; }
        public string? Description { get; set; }
    }
}
