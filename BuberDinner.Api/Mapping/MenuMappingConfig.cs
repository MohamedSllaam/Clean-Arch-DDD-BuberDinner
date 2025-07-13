using BuberDinner.Application.Menus;
using BuberDinner.Contracts.Menu;
using BuberDinner.Domain.Menu;
using Mapster;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using MenuSection = BuberDinner.Domain.Menu.Entites.MenuSection;
using MenuItem = BuberDinner.Domain.Menu.Entites.MenuItem;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, Guid HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value.ToString())
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value.ToString()))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value.ToString()));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString());

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString());
    }
}