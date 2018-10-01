namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, Stock) VALUES ('Forrest Gump',5,2017-11-03, 2017-12-12,3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, Stock) VALUES ('Mad Max',1,2017-11-03, 2017-12-12,3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, Stock) VALUES ('The Spectacular Now',4,2017-11-03, 2017-12-12,3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, Stock) VALUES ('Die Hard',1,2017-11-03, 2017-12-12,3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, Stock) VALUES ('Up in the Air',4,2017-11-03, 2017-12-12,3)");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
