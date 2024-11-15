using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SeatsLeft { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public int[,] Seating { get; set; }
        public static string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Movie(string name, string description, decimal price, int duration, DateTime startDate, int[,] seating)
        {
            Name = name;
            Description = description;
            Price = price;
            Duration = duration;
            StartDate = startDate;
            Seating = seating;
            SeatsLeft = GetAvailableSeatCount();
        }

        public void PrintBookingDetails()
        {
            Console.WriteLine($"{Name} for ${Price} at {StartDate}");
        }
        public void PrintMovie()
        {
            Console.WriteLine("----------");
            Console.WriteLine(Name);
            Console.WriteLine(Description);
            Console.WriteLine($"${Price}");
            Console.WriteLine($"Seats: {SeatsLeft}");
            Console.WriteLine($"Duration: {Duration}");
            Console.WriteLine($"Show time: {StartDate}");
            Console.WriteLine("----------");

        }

        public bool CheckAvailable(int x, int y)
        {
            int seat = Seating[y, x];
            if (seat == 0)
            {
                return true;
            }
            return false;
        }

        public bool BookSeat(int x, int y)
        {
            if (CheckAvailable(x, y))
            {
                Seating[y, x] = 1;
                SeatsLeft--;
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetAvailableSeatCount()
        {
            int seatCount = 0;
            for (int i = 0; i < Seating.GetLength(0); i++)
            {
                for (int j = 0; j < Seating.GetLength(1); j++)
                {
                    if (Seating[i, j] == 0)
                    {
                        seatCount++;
                    }
                }
            }
            return seatCount;
        }

        public void PrintSeating()
        {
            Console.WriteLine("Movie Seating: 0 = free and 1 = taken");
            Console.WriteLine("");
            Console.Write("   ");
            for (int k = 1; k <= Seating.GetLength(1); k++)
            {
                Console.Write(" " + k + "  ");
            }
            Console.WriteLine();
            for (int i = 0; i < Seating.GetLength(0); i++)
            {
                Console.Write(ALPHABET[i] + "  ");
                for (int j = 0; j < Seating.GetLength(1); j++)
                {
                    Console.Write(" " + Seating[i, j] + " |");

                }
                Console.WriteLine();
            }
        }
    }

}
