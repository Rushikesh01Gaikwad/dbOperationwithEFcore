using Microsoft.EntityFrameworkCore;

namespace dbOperationEFcore.Data
{
    public class dbContext: DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) 
        {
           
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}

        public DbSet<book> books { get; set; }
        public DbSet<language>  Languages { get; set; }
        public DbSet<bookPrice> booksPrices { get; set; }
        public DbSet<currency> currencies { get; set; }
        public DbSet<Author> authors { get; set; }

    }
}
