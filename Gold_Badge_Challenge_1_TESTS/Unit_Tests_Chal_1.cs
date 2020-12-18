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


        //CREATE METHOD TEST (((DONE)))
        [TestMethod]
        public void TestCreateMethod_ShouldReturnTrue()
        {
            //ARRANGE -- set up the data or controlled environment for the test to run
            MenuItemRepo menuItemRepo = new MenuItemRepo();
            MenuItem itemToAdd = new MenuItem("TestMenuItem");


            //Act -- now call the method to be tested
            menuItemRepo.AddMenuItemToMenu(itemToAdd);

            //Assert -- method has run; now we write some lines to confirm that it behaved the way it should
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

        //READ METHOD TEST (((DONE)))
        [TestMethod]
        public void TestReadMethod_ShouldNotBeNull()
        {
            //ARRANGE -- set up the data or controlled environment for the test to run
            //TestInitialize

            //Act -- now call the method to be tested
            List<MenuItem> listFromRepo = _menuItemRepo.GetWholeMenu();

            //Assert -- method has run; now we write some lines to confirm that it behaved the way it should
            Assert.IsNotNull(listFromRepo);


        }

        //HELPER METHOD TEST (((DONE)))
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

        //DELETE METHOD TEST (((DONE)))
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
