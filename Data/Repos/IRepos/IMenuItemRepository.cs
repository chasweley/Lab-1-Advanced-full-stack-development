using Labb_1___Avancerad_fullstackutveckling.Models;

namespace Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos
{
    public interface IMenuItemRepository
    {
        Task<MenuItem> GetMenuItemByIdAsync(int menuItemId);
        Task CreateMenuItemAsync(MenuItem menuItem);
        Task UpdateMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(int menuItemId);
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<IEnumerable<MenuItem>> GetAllPopularEntreesAsync();
    }
}
