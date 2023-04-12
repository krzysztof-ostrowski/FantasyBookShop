using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyBookShop.Server.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookVariants",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookVariants", x => new { x.BookId, x.BookTypeId });
                    table.ForeignKey(
                        name: "FK_BookVariants_BookTypes_BookTypeId",
                        column: x => x.BookTypeId,
                        principalTable: "BookTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookVariants_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien" },
                    { 2, "Charles Soule" },
                    { 3, "Andrzej Sapkowski" },
                    { 4, "John Flanagan" },
                    { 5, "Mike Chen" }
                });

            migrationBuilder.InsertData(
                table: "BookTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hard Cover Book" },
                    { 2, "Paperback Book" },
                    { 3, "Audio Book" },
                    { 4, "E-Book" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "ImageUrl", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, "The Lord of the Rings is an epic[1] high-fantasy novel[a] by English author and scholar J. R. R. Tolkien. Set in Middle-earth, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.", "https://upload.wikimedia.org/wikipedia/en/e/e9/First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif", new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the rings" },
                    { 2, "Star Wars: The High Republic: Light of the Jedi is the first novel of the Star Wars: The High Republic multi-media project launched in 2021. The novel was written by Charles Soule, and is set approximately 200 years before the events of Star Wars: The Phantom Menace. It was followed by a sequel, The Rising Storm.", "https://upload.wikimedia.org/wikipedia/en/2/21/LOTJ_cover.jpg", new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "High Republic: Light of the Jedi" },
                    { 3, "The Witcher (Polish: Wiedźmin) is a series of six fantasy novels and 15 short stories written by Polish author Andrzej Sapkowski. The series revolves around the eponymous \"witcher\", Geralt of Rivia. In Sapkowski's works, \"witchers\" are beast hunters who develop supernatural abilities at a young age to battle wild beasts and monsters. The Witcher began with a titular 1986 short story that Sapkowski entered into a competition held by Fantastyka magazine, marking his debut as an author. Due to reader demand, Sapkowski wrote 14 more stories before starting a series of novels in 1994. Known as The Witcher Saga, he wrote one book a year until the fifth and final installment in 1999. A standalone prequel novel, Season of Storms, was published in 2013.", "https://upload.wikimedia.org/wikipedia/en/1/14/Andrzej_Sapkowski_-_The_Last_Wish.jpg", new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher" },
                    { 4, "Ranger's Apprentice is a series written by Australian author John Flanagan. It began as twenty short stories Flanagan wrote for his son to get him interested in reading. Ten years later, Flanagan found the stories again and decided to turn them into a book, which became the first novel in the series, The Ruins of Gorlan. It was originally released in Australia on 1 November 2004. Though the books were initially published only in Australia and New Zealand, they have since been released in 14 other countries.", "https://upload.wikimedia.org/wikipedia/en/d/d8/The_Ruins_of_Gorlan.jpg", new DateTime(2004, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ranger's Apprentice" },
                    { 5, "Obi-Wan Kenobi and Anakin Skywalker must stem the tide of the raging Clone Wars and forge a new bond as Jedi Knights.\r\nThe Clone Wars have begun. Battle lines are being drawn throughout the galaxy. With every world that joins the Separatists, the peace guarded by the Jedi Order is slipping through their fingers.", "https://static.wikia.nocookie.net/starwars/images/3/3d/Brotherhood_Final_Cover.png/revision/latest/scale-to-width-down/1000?cb=20220510224638", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Brotherhood" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Fantasy", "Fantasy" },
                    { 2, "Dark Fantasy", "DarkFantasy" },
                    { 3, "Sci-Fi", "SciFi" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 1 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "BookVariants",
                columns: new[] { "BookId", "BookTypeId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 1, 40m, 20m },
                    { 1, 2, 20m, 10m },
                    { 1, 4, 10m, 5m },
                    { 2, 2, 30m, 15m },
                    { 2, 4, 10m, 5m },
                    { 3, 2, 25m, 15m },
                    { 3, 3, 25m, 15m },
                    { 4, 1, 40m, 20m },
                    { 4, 2, 30m, 15m },
                    { 5, 2, 40m, 20m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookVariants_BookTypeId",
                table: "BookVariants",
                column: "BookTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "BookVariants");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
