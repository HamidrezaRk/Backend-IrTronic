namespace Domain.Entites.BaseEntities;

 public interface IUpdateBaseEntity
 {
    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedByID { get; set; }

    public UserEntity? UpdatedBy { get; set; }
}
