namespace KentuckyProudSeedCo.Data.Interface
{
    public interface ITrackable
    {
        DateTime? CreatedBy { get; set; } 
        DateTime? CreatedOn { get; set; }
        DateTime? ModifiedBy { get; set; }
        DateTime? ModifedOn { get; set; }
    }
}
