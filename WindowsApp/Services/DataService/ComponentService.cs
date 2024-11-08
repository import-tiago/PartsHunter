using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PartsHunter.Data;
using PartsHunter.Data.Entities;

namespace PartsHunter.Services.DataService
{
    public class ComponentService
    {
        private readonly PartsHunterContext _context;

        public ComponentService()
        {
            _context = new PartsHunterContext();
            _context.Database.EnsureCreated();
        }

        public List<Component> GetAllComponents()
        {
            return _context.Components.ToList();
        }

        public Component GetComponentById(int id)
        {
            return _context.Components.Find(id);
        }

        public void AddComponent(Component component)
        {
            _context.Components.Add(component);
            _context.SaveChanges();
        }

        public void UpdateComponent(Component component)
        {
            _context.Components.Update(component);
            _context.SaveChanges();
        }

        public void DeleteComponent(int id)
        {
            var component = _context.Components.Find(id);
            if (component != null)
            {
                _context.Components.Remove(component);
                _context.SaveChanges();
            }
        }

        // Search by description, case-insensitive using LIKE
        public List<Component> SearchComponentsByDescription(string searchTerm)
        {
            // Use EF.Functions.Like for case-insensitive search
            return _context.Components
                .Where(c => EF.Functions.Like(c.Description, "%" + searchTerm + "%"))
                .ToList();
        }

        // Search by description and category, case-insensitive using LIKE
        public List<Component> SearchComponentsByDescriptionAndCategory(string searchTerm, string category)
        {
            // Use EF.Functions.Like for case-insensitive search in both Description and Category
            return _context.Components
                .Where(c => EF.Functions.Like(c.Description, "%" + searchTerm + "%") && c.Category == category)
                .ToList();
        }

        // Get unique categories from the database
        public List<string> GetUniqueCategories()
        {
            return _context.Components
                .Select(c => c.Category)       // Select the Category column
                .Distinct()                    // Remove duplicates
                .ToList();                     // Convert to list
        }
    }
}
