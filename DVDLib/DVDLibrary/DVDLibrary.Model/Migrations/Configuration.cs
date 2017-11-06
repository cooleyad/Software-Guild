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
            context.Dvds.AddOrUpdate(
                d => d.Id,
                new Dvd
                {
                    Id = 1,
                    Title = "Bio-Dome",
                    ReleaseYear =1996,
                    DirectorName = "Jason Bloom",
                    RatingType = "PG-13",
                    Notes= "Sigh... what do you even say?"
                },
                new Dvd
                {
                    Id=2,
                    Title="I Am Legend",
                    ReleaseYear=2007,
                    DirectorName="Francis Lawrence",
                    RatingType="PG-13",
                    Notes="This movie has practically nothing to do with the book."
                },
                new Dvd
                {
                    Id=3,
                    Title="Ex Machina",
                    ReleaseYear=2014,
                    DirectorName="Alex Garland",
                    RatingType="R",
                    Notes="Sci-Fi meets small ensemble cast with exquisite results"
                },

                new Dvd
                {
                    Id=4,
                    Title="Spider-Pig",
                    ReleaseYear=2009,
                    DirectorName="Homer Simpson",
                    RatingType="PG-13",
                    Notes="Spider Pig, Spider Pig, does whatever a Spider Pig does... "

                }
                );
            context.SaveChanges();
        }
    }
}
