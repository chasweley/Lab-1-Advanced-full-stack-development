using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
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
            try
            {
                var menuItem = await _menuItemRepo.GetMenuItemByIdAsync(menuItemId);

                return menuItem;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public async Task CreateMenuItemAsync(CreateMenuItemDTO menuItem)
        {
            try
            {
                var newMenuItem = new MenuItem
                {
                    Name = menuItem.Name,
                    Price = menuItem.Price,
                    IsAvailable = menuItem.IsAvailable
                };

                await _menuItemRepo.CreateMenuItemAsync(newMenuItem);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to create menu item. {ex.Message}");
            }
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to update menu item. {ex.Message}");
            }

        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            try
            {
                await _menuItemRepo.DeleteMenuItemAsync(menuItemId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to delete menu item. {ex.Message}");
            }
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
