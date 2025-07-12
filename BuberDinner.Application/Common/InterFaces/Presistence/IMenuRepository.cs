
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.User;

namespace BuberDinner.Application.Common.InterFaces.Presistence
{
    public interface IMenuRepository
    {
         void Add(Menu menu);
    }
}