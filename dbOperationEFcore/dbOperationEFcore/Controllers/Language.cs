using dbOperationEFcore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dbOperationEFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Language : ControllerBase
    {
        private readonly dbContext _dbContext;

        public Language(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetLanguage()
        {
            var result = await _dbContext.Languages.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> getLanguageById( List<int> id)
        {
            //var result = await _dbContext.Languages.FindAsync(id); //it works only with primary key;
            var result = await _dbContext.Languages.Where(x => id.Contains(x.Id)).Select(x => new 
            {Id =  x.Id, Title = x.Title }).ToListAsync(); 
            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> getLangugeByName([FromRoute] string name)
        {
            //var result = await _dbContext.Languages.Where(x => x.Title == name).FirstOrDefaultAsync();
            //var result = await _dbContext.Languages.FirstOrDefaultAsync(x => x.Title == name); // performance improvement
            var result = await _dbContext.Languages.FirstOrDefaultAsync(x => x.Title == name || string.IsNullOrEmpty(name)); // check null or empty

            return Ok(result);
        }

    }
}
