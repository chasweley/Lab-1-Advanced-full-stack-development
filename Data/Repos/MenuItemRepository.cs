using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___Avancerad_fullstackutveckling.Data.Repos
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly TableBookingContext _context;

        public MenuItemRepository(TableBookingContext context)
        {
            _context = context;
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int menuItemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(menuItemId);
            return menuItem;
        }
 
        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(menuItemId);

            if (menuItem != null) 
            { 
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            var listOfAllMenuItems = await _context.MenuItems.ToListAsync();
            return listOfAllMenuItems;
        }
    }
}
