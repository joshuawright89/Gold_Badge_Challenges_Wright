
using Gold_Badge_Challenge_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenge_1_CONSOLE
{
    class ProgramUI_Chal_1
    {
        private MenuItemRepo _menuItemRepo = new MenuItemRepo();

        public void Run()
        {
            SeedData();
            while (UIMenu())
            {
                Console.WriteLine("Press a key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Signing off.\n" +
                "Press any key to exit.");
            Console.ReadKey();
        }

        //Seed helper
        private void SeedData()
        {
            var testItem1 = new MenuItem("tester1", "test number1", "description test1", "ingredients test1", "10.99");
            var testItem2 = new MenuItem("tester2", "test number2", "description test2", "ingredients test2", "7.49");
            var testItem3 = new MenuItem("tester3", "test number2", "description test3", "ingredients test3", "14.99");
            var testItem4 = new MenuItem("tester4", "test number4", "description test4", "ingredients test4", "9.99");
            _menuItemRepo.AddMenuItemToMenu(testItem1);
            _menuItemRepo.AddMenuItemToMenu(testItem2);
            _menuItemRepo.AddMenuItemToMenu(testItem3);
            _menuItemRepo.AddMenuItemToMenu(testItem4);
        }


        //Menu for the UI
        private bool UIMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Komodo Cafe Menu Control Center!\n" +
                "  Select an option below, using its respective [option number], to perform various tasks within our cafe menu.\n\n" +
                "[1] Create/Add a new item to Menu\n" +
                "[2] Display all Menu items\n" +
                "[3] Delete an existing Menu item\n" +
                "[0] Exit Control Center");

            switch (Console.ReadLine())
            {
                case "1":
                    //CREATE new menu item
                    CreateNewMenuItem();
                    break;
                case "2":
                    //READ existing menu items
                    DisplayExistingMenuItems();
                    break;
                case "3":
                    //DELETE existing menu item
                    DeleteExistingMenuItem();
                    break;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Enter [option number] for desired option (0-3).");
                    break;
            }
            return true;
        }

        //CreateNewMenuItem()
        private void CreateNewMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter a name for menu item:");
            string menuItemName = Console.ReadLine();

            Console.WriteLine("Assign a menu number to this item:");
            string menuItemNumber = Console.ReadLine();

            Console.WriteLine("Enter a description for this item:");
            string menuItemDescription = Console.ReadLine();

            Console.WriteLine("Enter all ingredients used when making this item:");
            string menuItemIngredients = Console.ReadLine();

            Console.WriteLine("Enter price for this item: (Format:x.xx; do NOT include $ symbol.)");
            string menuItemPrice = Console.ReadLine();

            MenuItem newMenuItem = new MenuItem(menuItemName, menuItemNumber, menuItemDescription, menuItemIngredients, menuItemPrice);
            _menuItemRepo.AddMenuItemToMenu(newMenuItem);
        }

        
        //DisplayExistingMenuItems(); [[[2]]]
        private void DisplayExistingMenuItems()
        {
            Console.Clear();
            var allMenuItems = _menuItemRepo.GetWholeMenu();
            foreach (var menuItem in allMenuItems)
            {
                DisplayMenuItemsPartial(menuItem);
            }
            Console.WriteLine();
        }


        //DeleteExistingMenuItem(); [[[3]]]
        private void DeleteExistingMenuItem()
        {
            Console.Clear();
            DisplayExistingMenuItems();
            Console.WriteLine("Enter menu item number of item you'd like to remove and press Enter:");
            string menuItemNumber = Console.ReadLine();
            Console.Clear();
            var menuItemToDelete = _menuItemRepo.GetItemByNumber(menuItemNumber);
            DisplayMenuItemFull(menuItemToDelete);
            Console.WriteLine("Confirm: Remove Menu Item? (y/n)");
            if (GetYesOrNo())
            {
                if (_menuItemRepo.DeleteMenuItem(menuItemNumber))
                {
                    Console.WriteLine("The item was successfully removed.");
                }
                else
                {
                    Console.WriteLine("The item was NOT removed.");
                }
            }
        }

        //Display Helpers
        private void DisplayMenuItemFull(MenuItem menuItem)
        {
            Console.WriteLine($"\tMenu Item Name: {menuItem.MenuItemName}");
            Console.WriteLine($"\tMenu Item Number: {menuItem.MenuItemNumber}");
            Console.WriteLine($"\tDescription: {menuItem.MenuItemDescription}");
            Console.WriteLine($"\tIngredients: {menuItem.MenuItemIngredients}");
            Console.WriteLine($"\tPrice: {menuItem.MenuItemPrice}");
        }
        private void DisplayMenuItemsPartial(MenuItem menuItem)
        {
            Console.WriteLine($"\n\tMenu Item Name: {menuItem.MenuItemName}");
            Console.WriteLine($"\tMenu Item Number: {menuItem.MenuItemNumber}");
            Console.WriteLine($"\tPrice: {menuItem.MenuItemPrice}");
        }

        //Yes or No answer method
        private bool GetYesOrNo()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        return false;
                }
                Console.WriteLine("Enter 'y' for yes, or 'n' for no.");
            }
        }
    }
}
