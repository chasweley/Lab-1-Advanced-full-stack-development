using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<MenuItem>> GetMenuItemById(int menuItemId)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);
            return Ok(menuItem);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateMenuItem(MenuItem menuItem)
        {
            await _menuItemService.CreateMenuItemAsync(menuItem);
            return Ok(menuItem);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateMenuItem(MenuItem menuItem)
        {
            await _menuItemService.UpdateMenuItemAsync(menuItem);
            return Ok(menuItem);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteMenuItem(int menuItemId)
        {
            await _menuItemService.DeleteMenuItemAsync(menuItemId);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetAllMenuItems()
        {
            var listOfMenuItems = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(listOfMenuItems);
        }
    }
}
