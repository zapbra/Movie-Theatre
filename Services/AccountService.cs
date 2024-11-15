using MovieTheatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre.Services
{
    public static class AccountService
    {

        public static void PrintMovies(Account account)
        {
            Console.WriteLine("Printing movies...");
            if (account.Movies.Count == 0)
            {
                Console.WriteLine("You have no movies booked");
            }
            else
            {
                foreach (Movie movie in account.Movies)
                {
                    movie.PrintMovie();
                }
            }
        }

        public static void PrintBalance(Account account)
        {
            Console.WriteLine("Printing account balance...");
            Console.WriteLine($"You have a balance of ${account.Balance}");
            if (account.Balance < 0)
            {
                Console.WriteLine("Warning! You have a negative account balance!");
            }
        }

        public static void DepositFunds(Account account)
        {
            Console.WriteLine($"Your current account balance is {account.Balance}");
            Console.WriteLine("Please type how much you would like to deposit");
            string depositAmount = Console.ReadLine();
            decimal depositAmountDecimal = Convert.ToDecimal(depositAmount);

            account.Balance += depositAmountDecimal;
            Console.WriteLine($"Successfully deposited ${depositAmountDecimal}");
            Console.WriteLine($"Your new balance is ${account.Balance}");
        }
    }
}
