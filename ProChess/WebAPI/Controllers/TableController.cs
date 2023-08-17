using Microsoft.AspNetCore.Mvc;
using Shared.Data;

namespace WebAPI.Controllers
{
    [Route("table")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly TableManager _tableManager;

        public TableController(TableManager tableManager)
        {
            _tableManager = tableManager;
        }

        [HttpGet("getTables")]
        public IEnumerable<string> GetTables()
        {
            return _tableManager.Tables.Where(x => x.Value < 2).Select(x => x.Key);
        }
    }
}
