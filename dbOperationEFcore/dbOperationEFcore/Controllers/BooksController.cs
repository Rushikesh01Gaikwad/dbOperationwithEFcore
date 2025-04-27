using dbOperationEFcore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dbOperationEFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(dbContext dbContext) : ControllerBase
    {
        [HttpPost("addSingle")]
        public async Task<IActionResult> AddNewBook(book book)
        {
            dbContext.books.Add(book); // For add a single record
            var author = new Author
            {
                Name = "Author Name",
                Email = "TestEmail@gmail.com"
            };
            book.author = author; // for add multiple records in two tables by hardcoded.
            await dbContext.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPost("addMultiple")]
        public async Task<IActionResult> AddBooks(List<book> book)
        {
            dbContext.books.AddRange(book); // For add a multiple records.
            await dbContext.SaveChangesAsync();
            return Ok(book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, book book)
        {
            var book1 = dbContext.books.FirstOrDefault(x => x.Id == id);
            if (book1 == null)
            {
                return NotFound();
            }
            book1.Title = book.Title;
            book1.description = book.description; // update data using multiple queries

            await dbContext.SaveChangesAsync();
            return Ok(book);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatesinglequeryBook(book book)
        {
            //dbContext.books.Update(book); // update data using single query
            dbContext.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
            //update data directly in single query single record.
            await dbContext.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPut("bulk")]
        public async Task<IActionResult> updateBookInBulk()
        {

            await dbContext.books.Where(x => x.LanguageId == 3).ExecuteUpdateAsync(x => x
            .SetProperty(p => p.description, "Updated description")
            .SetProperty(p => p.Title, p => p.Title + " updated")); // update data in bulk
            return Ok();
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> delete( int bookId)
        {
            //var book = await dbContext.books.FindAsync(bookId);
            //if (book == null)
            //{
            //    return NotFound();
            //}
            //dbContext.books.Remove(book); // delete data using single query


            //var book = new book { Id = bookId }; // create a new instance of book with the specified Id
            //dbContext.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            //faster method to delete single record.

            //if you are deleting multiple records then use this code.
            //var book1 = await dbContext.books.Where(x => x.Id < 3).ToListAsync();
            //dbContext.books.RemoveRange(book1); // delete data using multiple id's


            var book2 = await dbContext.books.Where(x => x.Id < 3).ExecuteDeleteAsync();
            //faster method to delete multiple records.

            await dbContext.SaveChangesAsync();
            
                return Ok();
        }
    }
}
