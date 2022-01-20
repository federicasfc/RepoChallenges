using System;
using System.Collections.Generic;
using ClaimsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTest
{
    [TestClass]
    public class ClaimRepoTest
    {
        //Fields
        private Claim _claim;

        private Claim _claimTwo;

        private ClaimRepository _repo;

        [TestInitialize]

        public void Arrange()
        {
            _claim = new Claim(ClaimType.Theft, "tv stolen", 500.00, new DateTime(2022, 01, 10), new DateTime(2022, 01, 20));

            _claimTwo = new Claim(ClaimType.Home, "tree fell and damaged roof", 5000.00, new DateTime(2021, 12, 02), new DateTime(2021, 12, 10));

            _repo = new ClaimRepository();

            _repo.AddClaimToRepo(_claim);
            _repo.AddClaimToRepo(_claimTwo);

        }
        [TestMethod]
        public void TestAddClaimToRepo_ShouldGetTrue()
        {
            //Arrange - test initialize
            //Act 
            bool result = _repo.AddClaimToRepo(_claim);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TestGetAllClaims_ShouldReturnCorrectQueue()
        {
            //Arrange- Test initialize

            //Act 
            Queue<Claim> result = _repo.GetAllClaims();

            //Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]

        public void TestGetNextClaim_ShouldReturnCorrectClaim()
        {
            Claim result = _repo.GetNextClaim();

            Assert.AreEqual(_claim.ClaimId, result.ClaimId);
        }

        [TestMethod]

        public void TestRemoveClaimFromRepo_ShouldGetTrue()
        {
            bool result = _repo.RemoveClaimFromRepo();

            Assert.IsTrue(result);

        }
    }
}
