using MyLibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryApp.Controllers
{
    public interface IAuthorReposytory
    {
        public Task<Author> DeleteAuthor(int id);
        public Task<Author> EditAuthor(Author author);
        public Task<Author> GetAuthor(int id);
        public Task<IEnumerable<AuthorForAddingANewBook>> GetAllAuthors();
        public Task<Author> AddNewAuthor(AuthorForAddingANewBook author);
    }
}
