using System.Collections.Generic;
using CinemaLibraryWebApp.Models;

namespace CinemaLibraryWebApp.Data
{
    public class DirectorMovie
    {
        public IEnumerable<Movie> movies;
        public Director Director;
    }
}
