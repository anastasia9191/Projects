using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
       public ICollection<BookAuthor> Books { get; set; }
      

    }
}
