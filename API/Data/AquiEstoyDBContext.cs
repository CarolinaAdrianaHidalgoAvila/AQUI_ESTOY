using AQUI_ESTOY.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AQUI_ESTOY.Data
{
    public class AquiEstoyDBContext : DbContext
    {

        public AquiEstoyDBContext(DbContextOptions<AquiEstoyDBContext> options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().ToTable("User");
            modelBuilder.Entity<UserEntity>().Property(d => d.Id).ValueGeneratedOnAdd();
        }
    }
}
