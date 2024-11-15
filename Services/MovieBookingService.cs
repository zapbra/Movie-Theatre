using MovieTheatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre.Services
{
    public class MovieBookingService
    {
        public Movie Movie { get; set; }
        public Account Account { get; set; }

        public MovieBookingService(Movie movie, Account account)
        {
            Movie = movie;
            Account = account;
        }


        public void PrintMenu()
        {
            Console.WriteLine($"---Booking Movie: {Movie.Name}---");
            Console.WriteLine("[0] Exit Booking");
            Console.WriteLine("[1] Show Movie Details");
            Console.WriteLine("[2] Show available seats");
            Console.WriteLine("[3] Book seat");
        }

        public void BookSeat()
        {
            bool isBooking = true;
            while (isBooking)
            {

                Console.WriteLine("Which seat would you like to book? Type A1, A2, B3, etc...");
                string userInputString = Console.ReadLine();
                userInputString = userInputString.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0].ToUpper();
                int y = Movie.ALPHABET.IndexOf(userInputString[0]);
                int x = int.Parse(userInputString[1] + "") - 1;
                bool seatAvailable = Movie.CheckAvailable(x, y);

                if (seatAvailable)
                {
                    Console.WriteLine("Seat is available. Details below.");
                    Movie.PrintBookingDetails();
                    Console.WriteLine("Would you like to purchase this ticket? (y/n)");
                    char userInput = Console.ReadLine().ToUpper()[0];
                    if (userInput == 'Y')
                    {
                        if (Account.Purchase(Movie))
                        {
                            if (Movie.BookSeat(x, y))
                            {
                                Console.WriteLine($"Successfully booked {Movie.Name} for ${Movie.Price} at {Movie.StartDate}");
                            }
                            else
                            {
                                Console.WriteLine("Unable to book seat. Seat is taken");
                            }
                            isBooking = false;
                        }
                        else
                        {
                            Console.WriteLine($"Unable to book seat. Account balance is too low. {Account.Balance}");
                            isBooking = false;
                        }
                    }
                    else
                    {
                        isBooking = false;
                    }
                }
                else
                {

                }
            }




        }
        public void StartBookingLoop()
        {
            bool isBooking = true;
            while (isBooking)
            {
                int userInput = -1;
                PrintMenu();
                do
                {
                    Console.WriteLine($"Please select a menu item between 0 and 3");
                    string userInputString = Console.ReadLine();
                    int.TryParse(userInputString, out userInput);
                } while (!(userInput >= 0 && userInput <= 4));

                if (userInput == 0)
                {
                    break;
                }
                switch (userInput)
                {
                    case 1:
                        Movie.PrintMovie();
                        break;
                    case 2:
                        Movie.PrintSeating();
                        break;

                    case 3:
                        BookSeat();
                        break;

                    default:
                        break;

                }

            }
        }
    }
}
