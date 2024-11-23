using Microsoft.EntityFrameworkCore;
using PartsHunter.Data.Entities;

namespace PartsHunter.Data {
    public class PartsHunterContext : DbContext {
        public DbSet<ComponentEntity> Components { get; set; }
        public DbSet<HardwareDeviceEntity> HardwareDevice { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=PartsHunter.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HardwareDeviceEntity>().ToTable("HardwareDevice");
        }

    }
}
