using Microsoft.EntityFrameworkCore;
using PartsHunter.Data.Entities;

namespace PartsHunter.Data {
    public class PartsHunterContext : DbContext {
        public DbSet<Component> Components { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=parts_hunter.db");
        }
    }
}
