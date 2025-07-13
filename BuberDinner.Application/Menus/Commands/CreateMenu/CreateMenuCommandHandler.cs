using BuberDinner.Application.Common.InterFaces.Presistence;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entites;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
 public class CreateMenuCommandHandler(IMenuRepository _menuRepository) : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
 {
  public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
  {
     await Task.CompletedTask; // Simulating async operation, remove if not needed

            // Validate the request here if necessary
            // For example, check if the HostId exists or if the name is valid
    // Here you would typically interact with your repository or service to create the menu
            // For example:
             
       
    var menu = Menu.Create(
     hostId: HostId.Create(request.HostId),
     name: request.Name,
     description: request.Description,
     sections: request.Sections.ConvertAll(sections => MenuSection.Create(
         name: sections.Name,
         description: sections.Description,
         items: sections.Items.ConvertAll(items => MenuItem.Create(
             name: items.Name,
             description: items.Description)))));
    
    _menuRepository.Add(menu);
            return  menu;
  }
 }
}