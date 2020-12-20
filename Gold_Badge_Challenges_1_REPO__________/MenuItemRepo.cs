using System.Collections.Generic;

namespace Gold_Badge_Challenge_1
{
    public class MenuItemRepo
    {
        public List<MenuItem> _menu = new List<MenuItem>();

        //CREATE menu item
        public void AddMenuItemToMenu(MenuItem menuItem)
        {
            _menu.Add(menuItem);
        }

        //Display all menu items
        public List<MenuItem> GetWholeMenu()
        {
            return _menu;
        }

        //Helper (DELETE)
        public MenuItem GetItemByNumber(string menuItemNumber)
        {
            foreach (MenuItem menuItem in _menu)
            {
                if (menuItem.MenuItemNumber == menuItemNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }

        //DELETE menu item
        public bool DeleteMenuItem(string menuItemNumber)
        {
            MenuItem menuItem = GetItemByNumber(menuItemNumber);
            if (_menu.Remove(menuItem))
            {
                return true;
            }
            return false;
        }
    }
}
