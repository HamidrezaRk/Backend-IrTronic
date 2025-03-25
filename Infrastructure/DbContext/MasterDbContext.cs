using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;
 class MasterDbContext(DbContextOptions<MasterDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
 {

 }

