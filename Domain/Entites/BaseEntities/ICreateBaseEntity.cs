namespace Domain.Entites.BaseEntities;

 public interface ICreateBaseEntity
 {
    public DateTime CreatedAt { get; set; }

    public int? CreatedByUserID { get; set; }

    public UserEntity? CreatedBy { get; set; }
}
