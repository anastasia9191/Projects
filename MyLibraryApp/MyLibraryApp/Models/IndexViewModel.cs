using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryApp.Models
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishingDate { get; set; }
        public ICollection<string> Authors { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
