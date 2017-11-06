using DVDLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Model;
using DVDLibrary.Data;
using System.Data.Entity;

namespace DVDLibrary.Data.EF
{
    public class DvdRepositoryEF : IDvdRepository
    {
        DVDLibraryEntities dvdEntity = new DVDLibraryEntities();
        public void AddDvd(Dvd dvd)
        {
            if(dvdEntity.Dvds.Count()==0)
            {
                dvd.Id = 1;
            }
            else
            {
                var maxID = dvdEntity.Dvds.Max(d => d.Id);
                dvd.Id = maxID + 1;
            }
            dvdEntity.Dvds.Add(dvd);
            dvdEntity.SaveChanges();
        }

        public void DeleteDvd(int id)
        {
            Dvd dvd = dvdEntity.Dvds.Find(id);
            dvdEntity.Dvds.Remove(dvd);
            dvdEntity.SaveChanges();
        }

        public List<Dvd> DvdByDirector(string director)
        {
            return dvdEntity.Dvds.Where(d => d.DirectorName == director).ToList();
        }

        public List<Dvd> DvdByRating(string rating)
        {
            return dvdEntity.Dvds.Where(r => r.RatingType == rating).ToList();
        }

        public List<Dvd> DvdByTitle(string dvdTitle)
        {
            return dvdEntity.Dvds.Where(t => t.Title == dvdTitle).ToList();
        }

        public List<Dvd> DvdReleaseYear(int year)
        {
            return dvdEntity.Dvds.Where(y => y.ReleaseYear == year).ToList();
        }

        public void EditDvd(Dvd dvd)
        {
            dvdEntity.Entry(dvd).State = EntityState.Modified;
        }

        public List<Dvd> GetAll()
        {
            return dvdEntity.Dvds.ToList();
        }

        public Dvd GetDvdById(int id)
        {
            return dvdEntity.Dvds.FirstOrDefault(d => d.Id == id);
        }
    }
}
