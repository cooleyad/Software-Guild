using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Model
{
    public class Dvd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string DirectorName { get; set; }
        public string RatingType { get; set; }
        public string Notes { get; set; }
    }
}
