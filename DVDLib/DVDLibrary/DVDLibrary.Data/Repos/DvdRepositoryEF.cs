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
            if(dvdEntity.Dvd.Count()==0)
            {
                dvd.DvdId = 1;
            }
            else
            {
                var maxID = dvdEntity.Dvd.Max(d => d.DvdId);
                dvd.DvdId = maxID + 1;
            }
            dvdEntity.Dvd.Add(dvd);
            dvdEntity.SaveChanges();
        }

        public void DeleteDvd(int id)
        {
            Dvd dvd = dvdEntity.Dvd.Find(id);
            dvdEntity.Dvd.Remove(dvd);
            dvdEntity.SaveChanges();
        }

        public List<Dvd> DvdByDirector(string director)
        {
            return dvdEntity.Dvd.Where(d => d.Director == director).ToList();
        }

        public List<Dvd> DvdByRating(string rating)
        {
            return dvdEntity.Dvd.Where(r => r.Rating == rating).ToList();
        }

        public List<Dvd> DvdByTitle(string dvdTitle)
        {
            return dvdEntity.Dvd.Where(t => t.Title == dvdTitle).ToList();
        }

        public List<Dvd> DvdReleaseYear(int year)
        {
            return dvdEntity.Dvd.Where(y => y.ReleaseYear == year).ToList();
        }

        public void EditDvd(Dvd dvd)
        {
            dvdEntity.Entry(dvd).State = EntityState.Modified;
        }

        public List<Dvd> GetAll()
        {
            return dvdEntity.Dvd.ToList();
        }

        public Dvd GetDvdById(int id)
        {
            return dvdEntity.Dvd.FirstOrDefault(d => d.DvdId == id);
        }
    }
}
