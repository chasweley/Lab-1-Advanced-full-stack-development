using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<TableDTO>> GetTableById(int tableId)
        {
            var table = await _tableService.GetTableByIdAsync(tableId);
            return Ok(table);
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<ActionResult> CreateTable(CreateTableDTO table)
        {
            await _tableService.CreateTableAsync(table);
            return Ok("Table created successfully.");
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<ActionResult> UpdateTable(TableDTO table)
        {
            await _tableService.UpdateTableAsync(table);
            return Ok("Table updated successfully.");
        }

        [HttpDelete("Delete")]
        [Authorize]
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
