using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labb_1___Avancerad_fullstackutveckling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet("{menuItemId}")]
        [Authorize]
        public async Task<ActionResult<MenuItem>> GetMenuItemById(int menuItemId)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);
            return Ok(menuItem);
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<ActionResult> CreateMenuItem(CreateMenuItemDTO menuItem)
        {
            await _menuItemService.CreateMenuItemAsync(menuItem);
            return Ok("Menu item created successfully.");
        }

        [HttpPut("Update/")]
        [Authorize]
        public async Task<ActionResult> UpdateMenuItem(MenuItem menuItem)
        {
            await _menuItemService.UpdateMenuItemAsync(menuItem);
            return Ok("Menu item updated successfully.");
        }

        [HttpDelete("Delete/{menuItemId}")]
        [Authorize]
        public async Task<IActionResult> DeleteMenuItem(int menuItemId)
        {
            await _menuItemService.DeleteMenuItemAsync(menuItemId);

            return Ok("Menu item deleted successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetAllMenuItems()
        {
            var listOfMenuItems = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(listOfMenuItems);
        }

        [HttpGet("PopularEntrees")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetAllPopularEntrees()
        {
            var listOfPopularEntrees = await _menuItemService.GetAllPopularEntreesAsync();
            return Ok(listOfPopularEntrees);
        }
    }
}
