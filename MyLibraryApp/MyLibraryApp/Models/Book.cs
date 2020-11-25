using System;
using System.Collections.Generic;

namespace MyLibraryApp.Models
{
    public class Book 
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishingDate { get; set; }
        public ICollection<BookAuthor> Authors { get; set; }
       // public List<BookAuthor> BookAuthors { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
     
    }
}
