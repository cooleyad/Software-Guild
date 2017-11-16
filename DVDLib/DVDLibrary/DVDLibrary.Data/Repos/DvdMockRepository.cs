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
                DvdId=1,
                Title="The Dude",
                ReleaseYear=1996,
                Director="Lebowski",
                Rating="R",
                Notes="Like, it's about a rug, or something, Man..."
            },
            new Dvd
            {
                DvdId=2,
                Title="Some Indie Flick",
                ReleaseYear=2007,
                Director="Zach Braff",
                Rating="PG-13",
                Notes="We get it, you're having an existential crisis"
            },
            new Dvd
            {
                DvdId= 3,
                Title="2012",
                ReleaseYear=2012,
                Director="Some Guy",
                Rating="PG-13",
                Notes="Man Trump is making the end of the world look more appealing..."
            },
            new Dvd
            {
                DvdId=4,
                Title="Black Panther",
                ReleaseYear=2018,
                Director="Ryan Coogler",
                Rating="PG-13",
                Notes="I swear, if this movie sucks, I'm going to stop watching Marvel movies"
            }
        };
        public void AddDvd(Dvd dvd)
        {
            if (_dvds.Count()==0)
            {
                var maxId = _dvds.Max(d => d.DvdId);
                dvd.DvdId = maxId + 1;
            }
            else
            {
                dvd.DvdId = 1;
            }
            _dvds.Add(dvd);
        }

        public void DeleteDvd(int id)
        {
            //List<Dvd> dvd = new DvdMockRepository().GetAll();
            _dvds.RemoveAll(d => d.DvdId == id);
        }

        public List<Dvd> DvdByDirector(string director)
        {
            return _dvds.Where(d => d.Director == director).ToList();
        }

        public List<Dvd> DvdByRating(string rating)
        {
            return _dvds.Where(r => r.Rating == rating).ToList();
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
            return _dvds.FirstOrDefault(d => d.DvdId == id);
        }
    }
}
