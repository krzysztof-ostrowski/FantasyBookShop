using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBookShop.Shared
{
    public class CartItem
    {
        public int BookId { get; set; }
        public int BookTypeId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
