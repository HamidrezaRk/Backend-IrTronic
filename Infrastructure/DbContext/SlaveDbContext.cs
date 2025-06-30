using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;

public class SlaveDbContext(DbContextOptions<MasterDbContext> options) :
MasterDbContext(options)
{

}
