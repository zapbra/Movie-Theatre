using MovieTheatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre.classes
{


    public class MovieHandler
    {
        Dictionary<string, Movie> movieDictionary = new Dictionary<string, Movie>
    {
    {"Dragon Ball", new Movie(name: "Dragon Ball DAIMA", description: "The world English dub premiere of \"Dragon Ball DAIMA\", the newest series in the Dragon Ball universe, will debut featuring the first three episodes of the series. ",
            price: 15.00m, duration: 78, startDate: new DateTime(2024, 11, 10, 18, 30, 0), seating: new int[10, 10]) },
    { "Avengers", new Movie(name: "Avengers: Endgame", description: "The climactic conclusion to the Avengers saga, where Earth's heroes unite to undo Thanos's actions and restore order.", price: 20.00m, duration: 181, startDate: new DateTime(2024, 11, 11, 20, 0, 0), seating: new int[10, 10]) },

    { "Star Wars", new Movie(name: "Star Wars: A New Hope", description: "The original Star Wars film that started the saga. Follow Luke Skywalker as he joins the rebellion against the Empire.", price: 12.50m, duration: 121, startDate: new DateTime(2024, 11, 12, 18, 45, 0), seating: new int[10, 10]) },

    { "Inception", new Movie(name: "Inception", description: "A mind-bending thriller that follows a group of thieves who enter dreams to steal secrets. Directed by Christopher Nolan.", price: 14.00m, duration: 148, startDate: new DateTime(2024, 11, 13, 19, 30, 0), seating: new int[10, 10]) },

    { "The Godfather", new Movie(name: "The Godfather", description: "A powerful drama that follows the Corleone crime family in this iconic film by Francis Ford Coppola.", price: 18.00m, duration: 175, startDate: new DateTime(2024, 11, 14, 18, 0, 0), seating: new int[10, 10]) },

    { "Harry Potter", new Movie(name: "Harry Potter and the Philosopher's Stone", description: "The first film in the Harry Potter series, introducing the magical world of Hogwarts and young wizard Harry Potter.", price: 13.50m, duration: 152, startDate: new DateTime(2024, 11, 15, 16, 30, 0), seating: new int[10, 10]) },

    { "Jurassic Park", new Movie(name: "Jurassic Park", description: "A thrilling adventure where dinosaurs are brought back to life on a remote island, directed by Steven Spielberg.", price: 15.00m, duration: 127, startDate: new DateTime(2024, 11, 16, 19, 15, 0), seating: new int[10, 10]) },

    { "The Matrix", new Movie(name: "The Matrix", description: "A cyberpunk sci-fi film where reality is questioned, and humanity fights against intelligent machines. Directed by the Wachowskis.", price: 14.50m, duration: 136, startDate: new DateTime(2024, 11, 17, 20, 0, 0), seating: new int[10, 10]) },

    { "Toy Story", new Movie(name: "Toy Story", description: "The beloved animated film where toys come to life, starring Woody and Buzz Lightyear.", price: 10.00m, duration: 81, startDate: new DateTime(2024, 11, 18, 14, 0, 0), seating: new int[10, 10]) },

    { "Titanic", new Movie(name: "Titanic", description: "A romantic drama set on the ill-fated voyage of the RMS Titanic, directed by James Cameron.", price: 17.00m, duration: 195, startDate: new DateTime(2024, 11, 19, 18, 0, 0), seating: new int[10, 10]) }


    };

        public Movie? GetMovie(string name)
        {
            if (movieDictionary.TryGetValue(name, out Movie movie))
            {
                return movie;
            } else
            {
                return null;
            }
        }
        public void PrintMovies()
        {
            foreach (KeyValuePair<string, Movie> movie in movieDictionary)
            {
                Console.WriteLine($"{movie.Value.Name}");
                Console.WriteLine($"{movie.Value.Description}");
                Console.WriteLine($"${movie.Value.Price}");
                Console.WriteLine($"Seats Left: {movie.Value.SeatsLeft}");
                Console.WriteLine($"{movie.Value.Duration} mins");
                Console.WriteLine($"{movie.Value.StartDate}");
                Console.WriteLine("");
                Console.WriteLine("-------------------------");
                Console.WriteLine("");
            }
        }
    }
}
