using DVDLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Model;

namespace DVDLibrary.Data
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public void DeleteDvd(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> DvdByDirector(string director)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> DvdByRating(string rating)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> DvdByTitle(string dvdTitle)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> DvdReleaseYear(int year)
        {
            throw new NotImplementedException();
        }

        public void EditDvd(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetAll()
        {
            throw new NotImplementedException();
        }

        public Dvd GetDvdById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
