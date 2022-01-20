using System.Collections.Generic;
using CafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class MenuRepoTest
    {
        //Fields -- These fields have to be declared out here so that they can be accessed by all the methods (issue of scope)
        //       -- However, they are initialized in the TestInitialize because that runs before all of the other tests and will ensure that all the tests begin with the same content. 


        private MenuItem _item;

        private MenuRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            //This is where to test the repo

            _item = new MenuItem(4, "Fries", "Side of classic fries", new List<string> { "potatoes", "salt", "oil" }, 2.00);

            _repo = new MenuRepository();

            _repo.AddItemToRepo(_item);


        }

        [TestMethod]

        public void TestAddToRepo_ShouldGetTrue()
        {
            //Arrange
            //Using Arrange Method from TestInitialize

            //Act
            bool result = _repo.AddItemToRepo(_item);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TestGetAllMenuItems_ShouldReturnCorrectList()
        {
            //Arrange
            //Using TestInitialize, but also adding a few more MenuItems to _repo to make list

            MenuItem itemTwo = new MenuItem(5, "Ice Cream", "Two scoops of classic vanilla frozen treat", new List<string> { "sugar", "milk", "vanilla flavor", "ice" }, 2.00);
            _repo.AddItemToRepo(itemTwo);

            //Act
            List<MenuItem> result = _repo.GetAllMenuItems();
            //Arrange
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]

        public void TestGetMenuItemByName_ShouldReturnCorrectItem()
        {
            //Arrange- using test initialize and copy pasting itemTwo from above method because lazy
            MenuItem itemTwo = new MenuItem(5, "Ice Cream", "Two scoops of classic vanilla frozen treat", new List<string> { "sugar", "milk", "vanilla flavor", "ice" }, 2.00);
            _repo.AddItemToRepo(itemTwo);

            //Act
            MenuItem result = _repo.GetMenuItemByName("fries"); //not case sensitive anymore - added ToLower in MenuRepository GetMenuItemByName method

            //Assert
            Assert.AreEqual("Side of classic fries", result.Description);
        }


        [TestMethod]
        public void TestGetMenuItemByNumber_ShouldReturnCorrectItem()
        {
            //Arrange- using test initialize and copy pasting itemTwo from above method because lazy
            MenuItem itemTwo = new MenuItem(5, "Ice Cream", "Two scoops of classic vanilla frozen treat", new List<string> { "sugar", "milk", "vanilla flavor", "ice" }, 2.00);
            _repo.AddItemToRepo(itemTwo);

            //Act
            MenuItem result = _repo.GetMenuItemByNumber(4);

            //Assert
            Assert.AreEqual("Fries", result.Name);

        }


        [TestMethod]

        public void TestUpdateExistingItem_ShouldReturnUpdatedItem()
        {
            //Arrange
            MenuItem oldItem = _repo.GetMenuItemByName("Fries"); //Drawback of this test is that it relies on the correct functioning of another method (at least it's already tested)
            MenuItem newItem = new MenuItem(4, "French Fries", "fried potatoes", new List<string> { "potatoes", "salt", "oil" }, 2.50);

            //Act
            bool result = _repo.UpdateExistingItem("Fries", newItem);


            //Assert
            Assert.IsTrue(result); //Seems like there should be a better way to test this
            Assert.AreEqual("fried potatoes", oldItem.Description);
        }

        [TestMethod]

        public void TestDeleteContent_ShouldRemoveExistingItem()
        {
            //Arrange-Test Initialize
            //Act
            bool result = _repo.RemoveItemFromRepo(_item);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
