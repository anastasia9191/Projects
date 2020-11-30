using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryApp.Controllers
{
    public class SQLAuthorRepository : IAuthorReposytory
    {
        private readonly BookContext db;
        public SQLAuthorRepository(BookContext db)
        {
            this.db = db;
        }

        public async Task<Author> DeleteAuthor(int id)
        {
            var author = db.Authors.FirstOrDefault(c => c.AuthorId == id);
            db.Authors.Remove(author);
            await db.SaveChangesAsync();
            return author;
        }
        public async Task<Author> AddNewAuthor(AuthorForAddingANewBook author)
        {
            var newAuthor = new Author
            {
                Name = author.Name
            };
            var verification = db.Authors.Select(c => c.Name == author.Name).ToString();
            if (!string.IsNullOrEmpty(verification))
            {
                await db.Authors.AddAsync(newAuthor);
                await db.SaveChangesAsync();
            }
            return newAuthor;
        }
        public async Task<Author> EditAuthor(Author author)
        {
            var authorNew = db.Authors.FirstOrDefault(c => c.AuthorId == author.AuthorId);
            authorNew.Name = author.Name;
            authorNew.AuthorId = author.AuthorId;
            await db.SaveChangesAsync();
            return authorNew;
        }

        public async Task<IEnumerable<AuthorForAddingANewBook>> GetAllAuthors()
        {
            var authors = new List<AuthorForAddingANewBook>();
            var result = await db.Authors.ToListAsync();
            foreach(var item in result)
            {
                authors.Add
                (
                    new AuthorForAddingANewBook()

                    {
                        Name=item.Name
                    }
                        
                 );
            }

            return authors;
        }

        public async Task<Author> GetAuthor(int id)
        {
            var author = await db.Authors.FirstOrDefaultAsync(c => c.AuthorId == id);
            return author;
        }
    }
}
