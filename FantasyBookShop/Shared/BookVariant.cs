using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FantasyBookShop.Shared
{
    public class BookVariant
    {
        [JsonIgnore]
        public Book Book { get; set; }
        public int BookId { get; set; }
        public BookType BookType { get; set; }
        public int BookTypeId { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }

    }
}
