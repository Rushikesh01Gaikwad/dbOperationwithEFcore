using dbOperationEFcore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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


        [HttpGet]
        public async Task<IActionResult> getCurrency()
        {
            //var result = _dbContext.currencies.ToList();
            var result = await _dbContext.currencies.FromSqlRaw("select * from cuurency").ToListAsync();
            //var result1 = await _dbContext.currencies.ExecuteUpdateAsync("update cuurency set title=holly where id=2");
            return Ok(result);
        }

    }
}
