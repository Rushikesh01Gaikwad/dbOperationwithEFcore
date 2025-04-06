using Microsoft.EntityFrameworkCore;

namespace dbOperationEFcore.Data
{
    public class dbContext: DbContext
    {
        public dbContext(DbContextOptions<DbContext> options) : base(options) 
        {
            
        }

    }
}
