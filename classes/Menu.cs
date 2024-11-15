using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheatre.classes
{
    public class Menu
    {
        public int MenuOptionCount { get; set; }
        public MenuHandler MenuHandler { get; set; }
        public Dictionary<int, Menu> SubMenuDictionary { get; set; } = new Dictionary<int, Menu>();
        public delegate void ActionDelegate(int value);
        public Action PrintMenuAction { get; set; }
        public ActionDelegate HandleUserInputAction { get; set; }
        public Menu? ParentMenu { get; set; }

        public Menu(MenuHandler menuHandler, int menuOptionCount, Menu? parentMenu)
        {
            MenuHandler = menuHandler;
            MenuOptionCount = menuOptionCount;
            ParentMenu = parentMenu;

        }
        public void AddMenu(int key, Menu menu)
        {
            SubMenuDictionary.Add(key, menu);
        }
        public int GetUserInput()
        {
            int userInput = -1;
            do
            {
                Console.WriteLine($"Please select a menu item between 0 and {MenuOptionCount}");
                string userInputString = Console.ReadLine();
                int.TryParse(userInputString, out userInput);
            } while (!(userInput >= 0 && userInput <= MenuOptionCount));


            return userInput;
        }

        public void HandleUserInput(int value)
        {
            HandleUserInputAction?.Invoke(value);
        }

        public void PrintMenu()
        {
            PrintMenuAction?.Invoke();
        }
    }
}
