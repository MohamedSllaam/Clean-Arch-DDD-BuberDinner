using BuberDinner.Application.Common.InterFaces.Presistence;
using BuberDinner.Domain.Menu;
using BuberDinner.Infrastructure.Persistence;


namespace BuberDinner.Infrastructure.Presistence
{
    public class MenuRepository(BuberDinnerDbContext _buberDinnerDbContext) : IMenuRepository
    {
        private readonly List<Menu> _menus = new();



        public void Add(Menu menu)
        {
            // This is a mock implementation. In a real application, you would interact with a database.
            _buberDinnerDbContext.Add(menu);
            _buberDinnerDbContext.SaveChanges();
        }

        public Menu? GetMenuById(Guid id)
        {
       // This is a mock implementation. In a real application, you would query a database.
            return _buberDinnerDbContext.Menus.FirstOrDefault(m => m.Id.Value == id);
        }
    }
}