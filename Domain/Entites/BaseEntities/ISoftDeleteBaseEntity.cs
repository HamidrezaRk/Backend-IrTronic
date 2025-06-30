namespace Domain.Entites.BaseEntities;

 public interface ISoftDeleteBaseEntity
 {
    public bool IsDeleted { get; set; }
    public int? DeletedByUserID { get; set; }
    public UserEntity? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
