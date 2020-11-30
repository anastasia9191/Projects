using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyLibraryApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryApp.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository db;

        public BookController(IRepository db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<ShowAllBooksModel>> Index(int page = 1)
        {
            int pageSize = 3;
            List<ShowAllBooksModel> list = new List<ShowAllBooksModel>();
            IEnumerable<Book> result = await db.Get();

            var count = result.Count();
            var items = result.Skip((page - 1) * pageSize).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            List<ShowAllBooksModel> viewModel = new List<ShowAllBooksModel>();
            foreach (var value in items)
            {
                viewModel.Add(new ShowAllBooksModel
                {
                    Authors = value.Authors.Select(c => c.Author.Name).ToList(),
                    Description = value.Description,
                    Id = value.BookId,
                    Price = value.Price,
                    PublishingDate = value.PublishingDate,
                    Title = value.Title
                });
            }
            return viewModel;
        }

        // GET 
        [HttpGet("{id}")]
        public async Task<ShowAllBooksModel> GetBookById(int id)
        {
            ShowAllBooksModel bookModel = new ShowAllBooksModel();
            var result = await db.Get(id);
            bookModel = new ShowAllBooksModel
            {
                Authors = result.Authors?.Select(c => c.Author.Name).ToList(),
                Description = result.Description,
                Id = result.BookId,
                Price = result.Price,
                PublishingDate = result.PublishingDate,
                Title = result.Title
            };
            return bookModel;
        }
        [HttpGet("name/{name}")]
        public async Task<IEnumerable<ShowAllBooksModel>> GetBookByName(string name)
        {
            List<ShowAllBooksModel> bookNew = new List<ShowAllBooksModel>();
            var result = await db.GetBookByTitle(name);
            foreach(var book in result)
            {
                bookNew.Add(new ShowAllBooksModel
                {
                    Authors = book.Authors?.Select(c => c.Author.Name).ToList(),
                    Description = book.Description,
                    Id = book.BookId,
                    Price = book.Price,
                    PublishingDate = book.PublishingDate,
                    Title=book.Title
                }
                );
            }
            
            return bookNew;
        }

        // POST api/books
        [HttpPost]
        public async Task<Book> Post(AddNewBookModel book, AuthorForAddingANewBook author)
        {
            return await db.Post(book, author);
        }

        // PUT api/books/
        [HttpPut]
        public Book PutAuthorsInBooks(EditBookModel book, AuthorForAddingANewBook author)
        {
            return db.UpdateAuthorsInBooks(book, author);
        }

        [HttpPut("editbook")]
        public Book PutBook(EditModel book)
        {
            return db.UpdateExistingBook(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            return await db.Delete(id);
        }
    }
}

