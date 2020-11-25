using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibraryApp.Models;

namespace MyLibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorReposytory db;

        public AuthorController(IAuthorReposytory db)
        {
            this.db = db;
        }
        [HttpPost]
        public async Task<Author> PostAuthor(AuthorForAddingANewBook author)
        {
            return await db.AddNewAuthor(author);
        }
        // GET 
        [HttpGet("{id}/authors")]
        public Task<Author> GetByAuthorId(int id)
        {
            return db.GetAuthor(id);
        }
        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            return await db.DeleteAuthor(id);
        }
        [HttpGet]
        public async Task<IEnumerable<AuthorForAddingANewBook>> GetAuthors()
        {
            return await db.GetAllAuthors();
        }
    }
}
