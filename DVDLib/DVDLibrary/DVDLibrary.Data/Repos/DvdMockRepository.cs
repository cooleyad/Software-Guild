using DVDLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Model;

namespace DVDLibrary.Data.Repos
{
    class DvdMockRepository : IDvdRepository
    {
        private static List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd {
                Id=1,
                Title="The Dude",
                ReleaseYear=1996,
                DirectorName="Lebowski",
                RatingType="R",
                Notes="Like, it's about a rug, or something, Man..."
            },
            new Dvd
            {
                Id=2,
                Title="Some Indie Flick",
                ReleaseYear=2007,
                DirectorName="Zach Braff",
                RatingType="PG-13",
                Notes="We get it, you're having an existential crisis"
            },
            new Dvd
            {
                Id= 3,
                Title="2012",
                ReleaseYear=2012,
                DirectorName="Some Guy",
                RatingType="PG-13",
                Notes="MSan Trump is making the end of the world look more appealing..."
            },
            new Dvd
            {
                Id=4,
                Title="Black Panther",
                ReleaseYear=2018,
                DirectorName="Ryan Coogler",
                RatingType="PG-13",
                Notes="I swear, if this movie sucks, I'm going to stop watching Marvel movies"
            }
        };
        public void AddDvd(Dvd dvd)
        {
            if (_dvds.Count()==0)
            {
                dvd.Id = 1;
            }
            else
            {
                var maxId = _dvds.Max(d => d.Id);
                dvd.Id = maxId + 1;
            }
            _dvds.Add(dvd);
        }

        public void DeleteDvd(int id)
        {
            _dvds.RemoveAll(d => d.Id == id);
        }

        public List<Dvd> DvdByDirector(string director)
        {
            return _dvds.Where(d => d.DirectorName == director).ToList();
        }

        public List<Dvd> DvdByRating(string rating)
        {
            return _dvds.Where(r => r.RatingType == rating).ToList();
        }

        public List<Dvd> DvdByTitle(string dvdTitle)
        {
            return _dvds.Where(t => t.Title == dvdTitle).ToList();
        }

        public List<Dvd> DvdReleaseYear(int year)
        {
            return _dvds.Where(y => y.ReleaseYear == year).ToList();
        }

        public void EditDvd(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd GetDvdById(int id)
        {
            return _dvds.FirstOrDefault(d => d.Id == id);
        }
    }
}
