using MovieTheatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre.classes
{
    public class MenuHandler
    {
        public Menu CurrentMenu { get; set; }
        private bool isRunning = true;
        public Account Account = new Account();

        public void StartMenuLoop()
        {
            while (isRunning)
            {

                CurrentMenu.PrintMenu();
                int userInput = CurrentMenu.GetUserInput();
                // go back menu if user navigated backwards if menu has parent
                if (userInput == 0)
                {
                    if (CurrentMenu.ParentMenu != null)
                    {
                        CurrentMenu = CurrentMenu.ParentMenu;
                    }
                    else
                    {
                        isRunning = false;
                    }
                }
                else
                {
                    CurrentMenu.HandleUserInput(userInput);
                }

            }
        }
    }
}
