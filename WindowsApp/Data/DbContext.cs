using Microsoft.EntityFrameworkCore;
using PartsHunter.Data.Entities;
using System.Reflection.Emit;

namespace PartsHunter.Data {
    public class PartsHunterContext : DbContext {
        public DbSet<Component> Components { get; set; }
        public DbSet<HardwareDevice> ESP32 { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=parts_hunter.db");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HardwareDevice>().ToTable("ESP32");  // Ensure the table is named 'ESP32'
        }

    }
}
