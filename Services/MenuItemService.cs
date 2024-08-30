using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;

namespace Labb_1___Avancerad_fullstackutveckling.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepo;

        public MenuItemService(IMenuItemRepository menuItemRepo)
        {
            _menuItemRepo = menuItemRepo;
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int menuItemId)
        {
            var menuItem = await _menuItemRepo.GetMenuItemByIdAsync(menuItemId);

            return menuItem;
        }
        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            var newMenuItem = new MenuItem
            {
                Name = menuItem.Name,
                Price = menuItem.Price,
                IsAvailable = menuItem.IsAvailable
            };

            await _menuItemRepo.CreateMenuItemAsync(newMenuItem);
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            if (menuItem != null)
            {
                var updatedMenuItem = new MenuItem
                {
                    MenuItemId = menuItem.MenuItemId,
                    Name = menuItem.Name,
                    Price = menuItem.Price,
                    IsAvailable = menuItem.IsAvailable
                };
            
                await _menuItemRepo.UpdateMenuItemAsync(updatedMenuItem);
            }
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            await _menuItemRepo.DeleteMenuItemAsync(menuItemId);
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            var listOfMenuItems = await _menuItemRepo.GetAllMenuItemsAsync();

            return listOfMenuItems.Select(i => new MenuItem
            {
                MenuItemId = i.MenuItemId,
                Name = i.Name,
                Price = i.Price,
                IsAvailable = i.IsAvailable
            }).ToList();
        }
    }
}
