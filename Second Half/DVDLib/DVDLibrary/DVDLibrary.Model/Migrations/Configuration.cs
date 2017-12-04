namespace DVDLibrary.Model.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDLibrary.Model.DVDLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDLibrary.Model.DVDLibraryEntities context)
        {
            context.Dvd.AddOrUpdate(
                d => d.DvdId,
                new Dvd
                {
                    DvdId = 1,
                    Title = "The Dude",
                    ReleaseYear = 1996,
                    Director = "Lebowski",
                    Rating = "R",
                    Notes = "Like, it's about a rug, or something, Man..."

                },
                new Dvd
                {
                    DvdId = 2,
                    Title = "Some Indie Flick",
                    ReleaseYear = 2007,
                    Director = "Zach Braff",
                    Rating = "PG-13",
                    Notes = "We get it, you're having an existential crisis"

                },
                new Dvd
                {
                    DvdId = 3,
                    Title = "2012",
                    ReleaseYear = 2012,
                    Director = "Some Guy",
                    Rating = "PG-13",
                    Notes = "MSan Trump is making the end of the world look more appealing..."
                },

                new Dvd
                {
                    DvdId = 4,
                    Title = "Black Panther",
                    ReleaseYear = 2018,
                    Director = "Ryan Coogler",
                    Rating = "PG-13",
                    Notes = "I swear, if this movie sucks, I'm going to stop watching Marvel movies"
                }
                );
            context.SaveChanges();
        }
    }
}
