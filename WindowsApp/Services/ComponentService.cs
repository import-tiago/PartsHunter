using Microsoft.EntityFrameworkCore;
using PartsHunter.Data;
using PartsHunter.Data.Entities;

namespace PartsHunter.Services {
    public class ComponentService {
        private readonly PartsHunterContext _context;

        public ComponentService() {
            _context = new PartsHunterContext();
            _context.Database.EnsureCreated();
        }
        public List<ComponentEntity> GetAllComponents() {
            return _context.Components.OrderBy(c => c.SlotID).ToList();
        }

        public ComponentEntity? GetComponentById(int id) {
            return _context.Components.Find(id);
        }
        public void AddComponent(ComponentEntity component) {

            var existingComponent = _context.Components.FirstOrDefault(c => c.SlotID == component.SlotID);

            if (existingComponent != null) {
                existingComponent.Description = component.Description;
                existingComponent.Category = component.Category;
                _context.Components.Update(existingComponent);
            }
            else {
                _context.Components.Add(component);
            }

            _context.SaveChanges();
        }
        public void UpdateComponent(ComponentEntity component) {
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
        public List<ComponentEntity> SearchComponentsByDescription(string searchTerm) {
            return _context.Components
                .Where(c => EF.Functions.Like(c.Description, "%" + searchTerm + "%"))
                .ToList();
        }
        public List<ComponentEntity> SearchComponentsByDescriptionAndCategory(string searchTerm, string category) {
            return _context.Components
                .Where(c => EF.Functions.Like(c.Description, "%" + searchTerm + "%") && c.Category == category)
                .ToList();
        }
        public List<string> GetUniqueCategories() {
            return _context.Components
                .Where(c => c.Category != null)
                .Select(c => c.Category!)
                .Distinct()
                .ToList();
        }
        public List<ComponentEntity> GetComponentsByCategory(string category) {
            return _context.Components
                .Where(c => c.Category == category)
                .ToList();
        }
    }
}