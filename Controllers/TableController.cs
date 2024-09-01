using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_1___Avancerad_fullstackutveckling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet("{tableId}")]
        public async Task<ActionResult<TableDTO>> GetUserById(int tableId)
        {
            var table = await _tableService.GetTableByIdAsync(tableId);
            return Ok(table);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUser(CreateTableDTO table)
        {
            await _tableService.CreateTableAsync(table);
            return Ok("Table created successfully.");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateUser(TableDTO table)
        {
            await _tableService.UpdateTableAsync(table);
            return Ok("Table updated successfully.");
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteUser(int tableId)
        {
            await _tableService.DeleteTableAsync(tableId);
            return Ok("Table deleted successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDTO>>> GetAllTables()
        {
            var listOfTables = await _tableService.GetAllTablesAsync();
            return Ok(listOfTables);
        }

        [HttpGet("Availability/{dateTime}")]
        public async Task<ActionResult<IEnumerable<TableDTO>>> AvailableTablesSpecificDateAndTime(DateTime dateTime)
        {
            var listOfAvailableTables = await _tableService.AvailableTablesSpecificDateAndTimeAsync(dateTime);
            return Ok(listOfAvailableTables);
        }
    }
}
