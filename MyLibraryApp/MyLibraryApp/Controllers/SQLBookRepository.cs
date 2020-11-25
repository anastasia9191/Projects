using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyLibraryApp.Controllers
{
    public class SQLBookRepository : IRepository
    {
        private readonly BookContext db;

        public SQLBookRepository(BookContext db)
        {
            this.db = db;
           
        }
        public async Task<Book> Delete(int id)
        {
            Book user = db.Books.Include(c => c.Authors).ThenInclude(c => c.Author).FirstOrDefault(x => x.BookId == id);
            db.Books.Remove(user);
            await db.SaveChangesAsync();
            return user;
        }
      

        public async Task<IEnumerable<Book>> Get()
        {

            return await db.Books.Include(c=>c.Authors).ThenInclude(c=>c.Author).ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            Book book = await db.Books.Include(c => c.Authors).ThenInclude(c => c.Author).FirstOrDefaultAsync(x => x.BookId == id);
            return book;
        }

        public async Task<Book> GetBookByTitle(string title)
        {
            Book book = await db.Books.Include(c => c.Authors).ThenInclude(c => c.Author).FirstOrDefaultAsync(x => x.Title == title);
            return book;
        }

        public Author GetByAuthorName(int id)
        {
            return db.Authors.FirstOrDefault(x => x.AuthorId == id);
        }

        public async Task<Book> Post(AddNewBookModel book, AuthorForAddingANewBook author)
        {
            var book1 = new Book {
                Description = book.Description,
                Price = book.Price,
                PublishingDate = book.PublishingDate,
                Title = book.Title
            };
            var author1 = new Author
            {
                Name = author.Name
            };
            var newAuthor = db.Authors.FirstOrDefault(p => p.Name == author1.Name);
            book1.Authors = new List<BookAuthor>
              {
                new BookAuthor {
                    Author = author1,
                    Book = book1
                    },
                };
            
            await db.Books.AddAsync(book1);
            await db.SaveChangesAsync();
            return book1;
        }

      

        public Book UpdateAuthorsInBooks(EditBookModel book, AuthorForAddingANewBook author)
        {
            var book1 = new Book
            {
                Description = book.Description,
                Price = book.Price,
                PublishingDate = book.PublishingDate,
                Title = book.Title,
                BookId = book.BookId
            };
            var author1 = new Author
            {
                Name = author.Name
            };

            var newBook = db.Books.Include(c => c.Authors).FirstOrDefault(x => x.BookId == book1.BookId);
            var newAuthor = db.Authors.FirstOrDefault(p => p.Name == author1.Name);
            newBook.Authors.Add(
                new BookAuthor
                {
                    Author = newAuthor,
                    Book = newBook
                });
            db.SaveChanges();
            return newBook;
        }
        public  Book UpdateExistingBook(EditModel editBook)
        {
            var newBook =  db.Books.Include(c => c.Authors).FirstOrDefault(x => x.BookId == editBook.BookId);

            newBook.Description = editBook.Description;
            newBook.Price = editBook.Price;
            newBook.PublishingDate = editBook.PublishingDate;
            newBook.Title = editBook.Title;
            newBook.BookId = editBook.BookId;

            db.SaveChanges();
            return newBook;
        }
    }
}
