using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;

namespace Labb_1___Avancerad_fullstackutveckling.Services.IServices
{
    public interface IMenuItemService
    {
        Task<MenuItem> GetMenuItemByIdAsync(int menuItemId);
        Task CreateMenuItemAsync(CreateMenuItemDTO menuItem);
        Task UpdateMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(int menuItemId);
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
    }
}
