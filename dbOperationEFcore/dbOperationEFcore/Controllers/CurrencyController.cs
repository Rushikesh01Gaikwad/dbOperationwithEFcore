using dbOperationEFcore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbOperationEFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly dbContext _dbContext;

        public CurrencyController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult getAllCurrency()
        {
            //var result = _dbContext.currencies.ToList();
            var result = (from currencies in _dbContext.currencies select currencies).ToList();
            return Ok(result);
        }

    }
}
