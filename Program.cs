// See https://aka.ms/new-console-template for more information
using MovieTheatre.classes;
using MovieTheatre.Models;
using MovieTheatre.Services;

MenuHandler menuHandler = new MenuHandler();
MovieHandler movieHandler = new MovieHandler();
Account account = new Account();
Menu mainMenu = new Menu(menuHandler: menuHandler, menuOptionCount: 2, parentMenu: null);
mainMenu.PrintMenuAction = () =>
{
    Console.WriteLine("---Main Menu---");
    Console.WriteLine("[0] Exit Main Menu");
    Console.WriteLine("[1] Buy Tickets");
    Console.WriteLine("[2] Account");
};
mainMenu.HandleUserInputAction = (int value) =>
{
    if (value == 0)
    {

    }
    Menu newMenu;
    switch (value)
    {
        case 1:
            newMenu = mainMenu.SubMenuDictionary[value];
            menuHandler.CurrentMenu = newMenu;
            break;
        case 2:
            newMenu = mainMenu.SubMenuDictionary[value];
            menuHandler.CurrentMenu = newMenu;
            break;
        default:
            break;
    }
};
menuHandler.CurrentMenu = mainMenu;


Menu ticketMenu = new Menu(menuHandler: menuHandler, menuOptionCount: 1, parentMenu: mainMenu);
ticketMenu.PrintMenuAction = () =>
{
    Console.WriteLine("---Ticket Menu---");
    Console.WriteLine("[0] Exit Ticket Menu");
    Console.WriteLine("[1] View showings");
};
ticketMenu.HandleUserInputAction = (int value) =>
{
    switch (value)
    {
        case 1:
            movieHandler.PrintMovies();
            Console.WriteLine("Please type the name of the movie you want to see");
            string userInputString = Console.ReadLine();
            Movie selectedMovie = movieHandler.GetMovie(userInputString);
            if (selectedMovie != null)
            {
                MovieBookingService movieBookingService = new MovieBookingService(selectedMovie, account);
                movieBookingService.StartBookingLoop();
            }
            else
            {

            }
            break;

        default:
            break;
    }
};
mainMenu.AddMenu(1, ticketMenu);


Menu accountMenu = new Menu(menuHandler: menuHandler, menuOptionCount: 3, parentMenu: mainMenu);
accountMenu.PrintMenuAction = () =>
{
    Console.WriteLine("---Account Menu---");
    Console.WriteLine("[0] Exit Account Menu");
    Console.WriteLine("[1] View booked movies");
    Console.WriteLine("[2] Show balance");
    Console.WriteLine("[3] Deposit funds");
};
accountMenu.HandleUserInputAction = (int value) =>
{
    switch (value)
    {
        case 1:
            AccountService.PrintMovies(account);
            break;
        case 2:
            AccountService.PrintBalance(account);
            break;
        case 3:
            AccountService.DepositFunds(account);
            break;
        default:
            break;
    }
};
mainMenu.AddMenu(2, accountMenu);

int userInput = -1;
Console.WriteLine("Welcome to the movie theatre");


bool isRunning = true;

menuHandler.StartMenuLoop();


