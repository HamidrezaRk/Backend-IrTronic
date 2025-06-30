namespace Domain.Entites.BaseEntities;

 public interface ICanceledBaseEntity
 {
    public DateTime CanceledAt { get; set; }

    public long? CanceledByID { get; set; }

    public UserEntity? CanceledBy { get; set; }
}
