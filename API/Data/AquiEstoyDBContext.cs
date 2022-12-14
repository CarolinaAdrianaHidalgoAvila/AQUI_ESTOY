using AQUI_ESTOY.Data.Entities;
using System.Data.Entity;

namespace AQUI_ESTOY.Data
{
    public class AquiEstoyDBContext : DbContext
    {
        public DbSet<UserEntity> Users => Set<UserEntity>();

        public AquiEstoyDBContext(DbContextOptions<AquiEstoyDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AquiEstoyDB");
            optionsBuilder.UseNpgsql(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().ToTable("User");
            modelBuilder.Entity<UserEntity>().Property(d => d.Id).ValueGeneratedOnAdd();

        }
    }
}
