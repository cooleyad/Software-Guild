using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Model
{
    public class DVDLibraryEntities : DbContext
    {
        public DVDLibraryEntities() : base("DVDLibrary")
        {

        }
        DbSet<Dvd> Dvd { get; set; }
    }
}
