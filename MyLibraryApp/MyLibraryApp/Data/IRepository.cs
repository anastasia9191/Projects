using MyLibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryApp.Controllers
{
    public interface IRepository 
    {
        public Task<IEnumerable<Book>> Get();
        public Task<Book> Get(int id);
        public Author GetByAuthorName(int id);
        public Task<Book> Post(AddNewBookModel book, AuthorForAddingANewBook author);
        public Book UpdateAuthorsInBooks(EditBookModel book, AuthorForAddingANewBook author);
        public Task<Book> Delete(int id);

       
        public Task<IEnumerable<Book>> GetBookByTitle(string title);
        public Book UpdateExistingBook(EditModel editBook);
    }
}
