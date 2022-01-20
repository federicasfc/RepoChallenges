using System.Collections.Generic;
using CafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class MenuRepoTest
    {
        //Fields (declaring, not initializing- still not sure why they aren't just initialized here)

        private MenuItem _item;

        private MenuRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            //This is where to test the repo
            //Here we will initialize the above fields with content, still unsure why

            _item = new MenuItem(4, "Fries", "Side of classic fries", new List<string> { "potatoes", "salt", "oil" }, 2.00);

            _repo = new MenuRepository();

            _repo.AddContentToRepo(_item);


        }

        [TestMethod]

        public void TestAddToRepo_ShouldGetTrue()
        {
            //Arrange
            //Using Arrange Method from TestInitialize

            //Act
            bool result = _repo.AddContentToRepo(_item);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TestGetAllMenuItems_ShouldReturnCorrectList()
        {
            //Arrange
            //Using TestInitialize, but also adding a few more MenuItems to _repo to make list

            MenuItem itemTwo = new MenuItem(5, "Ice Cream", "Two scoops of classic vanilla frozen treat", new List<string> { "sugar", "milk", "vanilla flavor", "ice" }, 2.00);
            _repo.AddContentToRepo(itemTwo);

            //Act
            List<MenuItem> result = _repo.GetAllMenuItems();
            //Arrange
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]

        public void TestGetMenuItemByName_ShouldReturnCorrectContent()
        {
            //Arrange- using test initialize and copy pasting itemTwo from above method because lazy
            MenuItem itemTwo = new MenuItem(5, "Ice Cream", "Two scoops of classic vanilla frozen treat", new List<string> { "sugar", "milk", "vanilla flavor", "ice" }, 2.00);
            _repo.AddContentToRepo(itemTwo);

            //Act
            MenuItem result = _repo.GetMenuItemByName("Fries"); //case sensitive still- ToLowerCase needed--add later

            //Assert
            Assert.AreEqual("Side of classic fries", result.Description);
        }

        //Maybe Add one for Update method at some point
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
        }

        [TestMethod]

        public void TestDeleteContent_ShouldRemoveExistingItem()
        {
            //Arrange-Test Initialize
            //Act
            bool result = _repo.RemoveContentFromRepo(_item);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
