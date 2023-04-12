using FantasyBookShop.Shared;
using Microsoft.EntityFrameworkCore;

namespace FantasyBookShop.Server.Data
{
    public class FantasyBookShopContext:DbContext
    {
        
        public FantasyBookShopContext(DbContextOptions<FantasyBookShopContext> options) :base(options) 
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<BookVariant> BookVariants { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookVariant>()
                .HasKey(b => new { b.BookId, b.BookTypeId });
            

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
            modelBuilder.Entity<BookCategory>()
                .HasOne(b => b.Book)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(b => b.Category)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Book)
                .WithMany(bc => bc.BookAuthors)
                .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Author)
                .WithMany(bc => bc.BookAuthors)
                .HasForeignKey(c => c.AuthorId);


            modelBuilder.Entity<BookType>().HasData(
                new BookType { Id = 1, Name = "Hard Cover Book" },
                new BookType { Id = 2, Name = "Paperback Book" },
                new BookType { Id = 3, Name = "Audio Book" },
                new BookType { Id = 4, Name = "E-Book" });

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "J.R.R. Tolkien" },
                new Author { Id = 2, Name = "Charles Soule" },
                new Author { Id = 3, Name = "Andrzej Sapkowski" },
                new Author { Id = 4, Name = "John Flanagan" },
                new Author { Id = 5, Name = "Mike Chen" } );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fantasy", Url = "Fantasy" },
                new Category { Id = 2, Name = "Dark Fantasy", Url = "DarkFantasy" },
                new Category { Id = 3, Name = "Sci-Fi", Url = "SciFi" });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Lord of the rings",
                    Description = "The Lord of the Rings is an epic[1] high-fantasy novel[a] by English author and scholar J. R. R. Tolkien. Set in Middle-earth, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e9/First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif",
                    PublishDate = new DateTime(1954, 7, 29),
                    Featured= true,
                },
                new Book
                {
                    Id = 2,
                    Title = "High Republic: Light of the Jedi",
                    Description = "Star Wars: The High Republic: Light of the Jedi is the first novel of the Star Wars: The High Republic multi-media project launched in 2021. The novel was written by Charles Soule, and is set approximately 200 years before the events of Star Wars: The Phantom Menace. It was followed by a sequel, The Rising Storm.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/21/LOTJ_cover.jpg",
                    PublishDate = new DateTime(2021, 1, 5),
                    Featured = true,
                },
                new Book
                {
                    Id = 3,
                    Title = "The Witcher",
                    Description = "The Witcher (Polish: Wiedźmin) is a series of six fantasy novels and 15 short stories written by Polish author Andrzej Sapkowski. The series revolves around the eponymous \"witcher\", Geralt of Rivia. In Sapkowski's works, \"witchers\" are beast hunters who develop supernatural abilities at a young age to battle wild beasts and monsters. The Witcher began with a titular 1986 short story that Sapkowski entered into a competition held by Fantastyka magazine, marking his debut as an author. Due to reader demand, Sapkowski wrote 14 more stories before starting a series of novels in 1994. Known as The Witcher Saga, he wrote one book a year until the fifth and final installment in 1999. A standalone prequel novel, Season of Storms, was published in 2013.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/14/Andrzej_Sapkowski_-_The_Last_Wish.jpg",
                    PublishDate = new DateTime(1993, 1, 1),
                    Featured = true
                },
                new Book
                {
                    Id = 4,
                    Title = "Ranger's Apprentice",
                    Description = "Ranger's Apprentice is a series written by Australian author John Flanagan. It began as twenty short stories Flanagan wrote for his son to get him interested in reading. Ten years later, Flanagan found the stories again and decided to turn them into a book, which became the first novel in the series, The Ruins of Gorlan. It was originally released in Australia on 1 November 2004. Though the books were initially published only in Australia and New Zealand, they have since been released in 14 other countries.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d8/The_Ruins_of_Gorlan.jpg",
                    PublishDate = new DateTime(2004, 11, 1)
                },
                new Book
                {
                    Id = 5,
                    Title = "Star Wars: Brotherhood",
                    Description = "Obi-Wan Kenobi and Anakin Skywalker must stem the tide of the raging Clone Wars and forge a new bond as Jedi Knights.\r\nThe Clone Wars have begun. Battle lines are being drawn throughout the galaxy. With every world that joins the Separatists, the peace guarded by the Jedi Order is slipping through their fingers.",
                    ImageUrl = "https://static.wikia.nocookie.net/starwars/images/3/3d/Brotherhood_Final_Cover.png/revision/latest/scale-to-width-down/1000?cb=20220510224638",
                    PublishDate = new DateTime(2022, 5, 10)
                });

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { AuthorId = 1, BookId = 1 },
                new BookAuthor { AuthorId = 2, BookId = 2 },
                new BookAuthor { AuthorId = 3, BookId = 3 },
                new BookAuthor { AuthorId = 4, BookId = 4 },
                new BookAuthor { AuthorId = 5, BookId = 5 });

            modelBuilder.Entity<BookCategory>().HasData(
                new BookCategory { BookId = 1, CategoryId = 1 },
                new BookCategory { BookId = 1, CategoryId = 2 },
                new BookCategory { BookId = 2, CategoryId = 3 },
                new BookCategory { BookId = 3, CategoryId = 1 },
                new BookCategory { BookId = 3, CategoryId = 2 },
                new BookCategory { BookId = 4, CategoryId = 1 },
                new BookCategory { BookId = 5, CategoryId = 3 }
                );

            modelBuilder.Entity<BookVariant>().HasData(
                new BookVariant { BookId = 1, BookTypeId = 1, Price = 20m, OriginalPrice = 40m },
                new BookVariant { BookId = 1, BookTypeId = 2, Price = 10m, OriginalPrice = 20m },
                new BookVariant { BookId = 1, BookTypeId = 4, Price = 5m, OriginalPrice = 10m },
                new BookVariant { BookId = 2, BookTypeId = 2, Price = 15m, OriginalPrice = 30m },
                new BookVariant { BookId = 2, BookTypeId = 4, Price = 5m, OriginalPrice = 10m },
                new BookVariant { BookId = 3, BookTypeId = 2, Price = 15m, OriginalPrice = 25m },
                new BookVariant { BookId = 3, BookTypeId = 3, Price = 15m, OriginalPrice = 25m },
                new BookVariant { BookId = 4, BookTypeId = 1, Price = 20m, OriginalPrice = 40m },
                new BookVariant { BookId = 4, BookTypeId = 2, Price = 15m, OriginalPrice = 30m },
                new BookVariant { BookId = 5, BookTypeId = 2, Price = 20m, OriginalPrice = 40m }
            );
                

        }
    }
}
