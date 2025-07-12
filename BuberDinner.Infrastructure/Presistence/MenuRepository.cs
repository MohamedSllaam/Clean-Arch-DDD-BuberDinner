using BuberDinner.Application.Common.InterFaces.Presistence;
using BuberDinner.Domain.Menu;


namespace BuberDinner.Infrastructure.Presistence
{
    public class MenuRepository : IMenuRepository
    {
        private readonly List<Menu> _menus = new();


        public void Add(Menu menu)
        {
            // This is a mock implementation. In a real application, you would interact with a database.
            _menus.Add(menu);
        }

        public Menu? GetMenuById(Guid id)
        {
       // This is a mock implementation. In a real application, you would query a database.
            return _menus.FirstOrDefault(m => m.Id.Value == id);
        }
    }
}