using Gold_Badge_Challenge_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gold_Badge_Challenge_1_TESTS
{
    [TestClass]
    public class UnitTests_Chal_1
    {
        private MenuItemRepo _menuItemRepo;
        private MenuItem _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _menuItemRepo = new MenuItemRepo();
            _menuItem = new MenuItem("TestMenuItem");

            _menuItemRepo.AddMenuItemToMenu(_menuItem);
        }


        //CREATE test
        [TestMethod]
        public void TestCreateMethod_ShouldReturnTrue()
        {
            //ARRANGE
            MenuItemRepo menuItemRepo = new MenuItemRepo();
            MenuItem itemToAdd = new MenuItem("TestMenuItem");
            
            //Act
            menuItemRepo.AddMenuItemToMenu(itemToAdd);
            
            //Assert
            List<MenuItem> menuItemDirectory = menuItemRepo.GetWholeMenu();

            bool IdIsEqual = false; 
            foreach(MenuItem menuItem in menuItemDirectory)
            {
                if (menuItem.MenuItemName == itemToAdd.MenuItemName)
                {
                    IdIsEqual = true;
                    break;
                }
            }
            Assert.IsTrue(IdIsEqual);
        }

        //READ test
        [TestMethod]
        public void TestReadMethod_ShouldNotBeNull()
        {
            //ARRANGE([TestInitialize])

            //Act
            List<MenuItem> listFromRepo = _menuItemRepo.GetWholeMenu();

            //Assert
            Assert.IsNotNull(listFromRepo);


        }

        //HELPER (find item by number) test
        [TestMethod]
        public void TestGetItemByNumber()
        {
            //Arrange
            MenuItemRepo menuItemRepo = new MenuItemRepo();
            MenuItem itemToAdd = new MenuItem("TestDev");
            menuItemRepo.AddMenuItemToMenu(itemToAdd);

            //Act
            MenuItem menuItemByID = menuItemRepo.GetItemByNumber(itemToAdd.MenuItemNumber);

            //Assert
            Assert.AreEqual(itemToAdd, menuItemByID);

        }

        //DELETE test
        [TestMethod]
        public void TestDeleteMethod_ShouldReturnTrue()
        {
            //Arrange ie: [TestInitialize]

            //Act
            bool deleteResult = _menuItemRepo.DeleteMenuItem(_menuItem.MenuItemName);

            //Assert
            Assert.IsTrue(deleteResult);

        }

    }
}
