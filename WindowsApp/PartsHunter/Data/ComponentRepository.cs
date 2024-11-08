using System.Collections.Generic;
using System.Linq;
using PartsHunter.Data.Entities;

namespace PartsHunter.Data {
    public class ComponentRepository {
        private readonly PartsHunterContext _context;

        public ComponentRepository() {
            _context = new PartsHunterContext();
            _context.Database.EnsureCreated(); // Ensure database is created
        }

        public List<Component> GetAllComponents() {
            return _context.Components.ToList();
        }

        public Component GetComponentById(int id) {
            return _context.Components.Find(id);
        }

        public void AddComponent(Component component) {
            _context.Components.Add(component);
            _context.SaveChanges();
        }

        public void UpdateComponent(Component component) {
            _context.Components.Update(component);
            _context.SaveChanges();
        }

        public void DeleteComponent(int id) {
            var component = _context.Components.Find(id);
            if (component != null) {
                _context.Components.Remove(component);
                _context.SaveChanges();
            }
        }
    }
}
