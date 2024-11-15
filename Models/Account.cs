using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre.Models
{
    public class Account
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public decimal Balance { get; set; } = 100.00m;
        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }

        public bool Purchase(Movie movie)
        {
            if (Balance - movie.Price < 0)
            {
                return false;
            }
            else
            {
                Balance -= movie.Price;
                Movies.Add(movie);
                return true;
            }
        }

    }

}
