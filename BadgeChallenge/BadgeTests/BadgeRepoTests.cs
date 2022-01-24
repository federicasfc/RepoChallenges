using System.Collections.Generic;
using BadgeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeTests
{

    [TestClass]
    public class BadgeRepoTests
    {
        //Fields

        private Badge _badgeOne;

        private Badge _badgeTwo;

        private Badge _badgeThree;

        private BadgeRepository _repo;


        [TestInitialize]

        public void Arrange()
        {
            _badgeOne = new Badge(new List<string> { "A1", "A2", "A3", "A4" }, "NameOne");

            _badgeTwo = new Badge(new List<string> { "B1", "B2", "B3", "B4" }, "NameTwo");

            _badgeThree = new Badge(new List<string> { "C1", "C2", "C3", "C4" }, "NameThree");

            _repo = new BadgeRepository();


            _repo.AddNewBadgeToRepo(_badgeOne);
            _repo.AddNewBadgeToRepo(_badgeTwo);
            _repo.AddNewBadgeToRepo(_badgeThree);

        }

        [TestMethod]
        public void TestAddNewBadgeToRepo_ShouldGetTrue()
        {
            //Arrange
            //Using TestInitialize

            //Act
            bool result = _repo.AddNewBadgeToRepo(_badgeOne); //Won't work if I run it again because I already added _badgeOne in the Assert- will work if that line is commented out.

            //Arrange
            Assert.IsTrue(result);


        }

        [TestMethod]

        public void TestGetAllBadges_ShouldReturnCorrectDictCount()
        {
            //Arrange
            //Using TestInitialize

            //Act
            Dictionary<int, Badge> result = _repo.GetAllBadges();

            //Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]

        public void TestGetBadgeByIdNumber_ShouldReturnCorrectBadge()
        {
            //Arrange - using TI

            //Act
            Badge result = _repo.GetBadgeByIdNumber(3);

            //Assert
            Assert.AreEqual("NameThree", _badgeThree.BadgeName);


        }
        [TestMethod]

        public void TestUpdateExistingBadge_ShouldReturnUpdatedBadge()
        {
            //Arrange - using TI
            Badge oldBadge = _repo.GetBadgeByIdNumber(2);
            Badge updatedBadge = new Badge(new List<string> { "D1", "D2", "D3", "D4" }, "NewName");
            //Act
            bool result = _repo.UpdateExistingBadge(2, updatedBadge);
            //Assert
            Assert.IsTrue(result); //works
            Assert.AreEqual("NewName", oldBadge.BadgeName); //Works, but have to comment out bool result variable and just call _repo.UpdateExistingBadge()



        }
    }
}
