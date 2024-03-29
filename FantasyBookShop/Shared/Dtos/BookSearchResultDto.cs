﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBookShop.Shared.Dtos
{
    public class BookSearchResultDto
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
