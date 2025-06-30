
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites.BaseEntities;
public class BaseEntity : ICreateBaseEntity, IUpdateBaseEntity, ISoftDeleteBaseEntity
{

    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    [ForeignKey("CreatedBy")]
    public int? CreatedByUserID { get; set; }
    public UserEntity? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    [ForeignKey("UpdatedBy")]
    public int? UpdatedByID { get; set; }
    public UserEntity? UpdatedBy { get; set; }

    [ForeignKey("DeletedBy")]
    public int? DeletedByUserID { get; set; }
    public UserEntity? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}

