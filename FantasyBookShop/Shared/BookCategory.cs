using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FantasyBookShop.Shared
{
    public class BookCategory
    {
        [JsonIgnore]
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
