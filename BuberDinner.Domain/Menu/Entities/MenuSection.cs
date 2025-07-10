using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public class MenuSection : Entity<MenuSectionId>
    {
        public string Name { get; }
        public string Description { get; }
        private readonly List<MenuItem> _items = new();


        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(
            MenuSectionId id,
            string name,
            string description) : base(id)
        {
            Name = name;
            Description = description;
        }
            
        public static MenuSection Create(
            string name,
            string description)
        {
            return new MenuSection(
                MenuSectionId.CreateUnique(),
                name,
                description);
        }
    }
    
}