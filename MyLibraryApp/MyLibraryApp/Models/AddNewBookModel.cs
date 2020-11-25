using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryApp.Models
{
    public class AddNewBookModel
    {
        public string Title { get; set; }
        public DateTime PublishingDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public AuthorForAddingANewBook authorName { get; set; }
    }
}
