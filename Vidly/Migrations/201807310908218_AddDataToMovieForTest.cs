namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToMovieForTest : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES (1, 'Hangover', '11/11/2000', '02/02/2016', 10, 1)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES (2, 'Die Hard', '11/11/2000', '02/02/2016', 10, 2)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES (3, 'The Terminator', '11/11/2000', '02/02/2016', 10, 3)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES (4, 'Toy Story', '11/11/2000', '02/02/2016', 10, 2)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES (5, 'Titanic', '11/11/2000', '02/02/2016', 10, 2)");
        }
       
        public override void Down()
        {
        }
    }
}
