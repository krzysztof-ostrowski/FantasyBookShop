using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FantasyBookShop.Shared
{
    public class BookAuthor
    {
        [JsonIgnore]
        public Book Book { get; set; }
        [Key]
        public int BookId { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
