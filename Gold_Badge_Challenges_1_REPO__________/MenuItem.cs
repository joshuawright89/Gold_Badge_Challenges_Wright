using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenge_1
{
    public class MenuItem
    {
        public string MenuItemNumber { get; set; }
        public string MenuItemName { get; }
        public string MenuItemDescription { get; }
        public string MenuItemIngredients { get; }
        public string MenuItemPrice { get; }

        public MenuItem(string menuItemName) { }

        public MenuItem(string menuItemName, string menuItemNumber, string menuItemDescription, string menuItemIngredients, string menuItemPrice)
        {
            MenuItemName = menuItemName;
            MenuItemNumber = menuItemNumber;
            MenuItemDescription = menuItemDescription;
            MenuItemIngredients = menuItemIngredients;
            MenuItemPrice = menuItemPrice;
        }
    }
}
