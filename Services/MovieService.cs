using MovieTheatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre.Services
{
    public static class MovieService
    {
        public static void PrintMovies(List<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                Console.WriteLine($"{movie.Name}");
                Console.WriteLine($"{movie.Description}");
                Console.WriteLine($"${movie.Price}");
                Console.WriteLine($"Seats Left: {movie.SeatsLeft}");
                Console.WriteLine($"{movie.Duration} mins");
                Console.WriteLine($"{movie.StartDate}");
                Console.WriteLine("");
                Console.WriteLine("-------------------------");
                Console.WriteLine("");
            }
        }
    }
}
