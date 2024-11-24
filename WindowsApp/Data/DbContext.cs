using Microsoft.EntityFrameworkCore;
using PartsHunter.Data.Entities;

namespace PartsHunter.Data {
    public class PartsHunterContext : DbContext {
        public DbSet<ComponentEntity> Components { get; set; }
        public DbSet<HardwareDeviceEntity> HardwareDevice { get; set; }
        private string dbPath = "Data\\Tables\\PartsHunter.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // Create directories if they do not exist
            var directory = Path.GetDirectoryName(dbPath);
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HardwareDeviceEntity>().ToTable("HardwareDevice");
        }
    }
}
