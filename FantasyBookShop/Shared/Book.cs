using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBookShop.Shared
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<BookVariant> Variants { get; set; }
        public bool Featured { get; set; } = false;
        public Book()
        {
            Variants = new List<BookVariant>();
        }
    }
}
