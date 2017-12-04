using DVDLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data.Interfaces
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        Dvd GetDvdById (int id);
        List<Dvd> DvdByTitle(string dvdTitle);
        List<Dvd> DvdReleaseYear(int year);
        List<Dvd> DvdByDirector(string director);
        List<Dvd> DvdByRating(string rating);
        void AddDvd(Dvd dvd);
        void EditDvd(Dvd dvd);
        void DeleteDvd(int id);
    }
}
