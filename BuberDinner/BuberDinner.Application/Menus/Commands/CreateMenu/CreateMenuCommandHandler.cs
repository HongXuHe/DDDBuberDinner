using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host.ValueObject;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler:IRequestHandler<CreateMenuCommand,Menu>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }
    public async Task<Menu> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var menu = Menu.Create(
            request.Name,
            request.Description,
            HostId.Create(request.HostId),
            request.Sections.ConvertAll(section =>MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item=>MenuItem.Create(item.Name,item.Description)))));
        _menuRepository.Add(menu);
        
        return menu;
        //throw new NotImplementedException();
    }
}