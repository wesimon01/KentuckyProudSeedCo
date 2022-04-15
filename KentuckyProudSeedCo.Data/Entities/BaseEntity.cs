namespace KentuckyProudSeedCo.Data.Entities
{
    public class BaseEntity
    {
        public DateTime? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedBy { get; set; }
        public DateTime? ModifedOn { get; set; }
    }
}
