namespace DVDLibrary.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDLibrary.Model.DVDLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDLibrary.Model.DVDLibraryEntities context)
        {
            context.Dvd.AddOrUpdate(
                d => d.Id,
                new Dvd
                {
                    Id = 1,
                    Title = "The Dude",
                    ReleaseYear = 1996,
                    DirectorName = "Lebowski",
                    RatingType = "R",
                    Notes = "Like, it's about a rug, or something, Man..."

                },
                new Dvd
                {
                    Id = 2,
                    Title = "Some Indie Flick",
                    ReleaseYear = 2007,
                    DirectorName = "Zach Braff",
                    RatingType = "PG-13",
                    Notes = "We get it, you're having an existential crisis"

                },
                new Dvd
                {
                    Id = 3,
                    Title = "2012",
                    ReleaseYear = 2012,
                    DirectorName = "Some Guy",
                    RatingType = "PG-13",
                    Notes = "MSan Trump is making the end of the world look more appealing..."
                },

                new Dvd
                {
                    Id = 4,
                    Title = "Black Panther",
                    ReleaseYear = 2018,
                    DirectorName = "Ryan Coogler",
                    RatingType = "PG-13",
                    Notes = "I swear, if this movie sucks, I'm going to stop watching Marvel movies"
                }
                );
            context.SaveChanges();
        }
    }
}
