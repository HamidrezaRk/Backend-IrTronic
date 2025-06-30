using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;

public class MasterDbContext(DbContextOptions<MasterDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
}
