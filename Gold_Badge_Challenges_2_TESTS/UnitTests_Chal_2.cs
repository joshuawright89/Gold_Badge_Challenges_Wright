using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gold_Badge_Challenges_2_REPO;
using System;
using System.Collections.Generic;

namespace Gold_Badge_Challenges_2_TESTS
{
    [TestClass]
    public class UnitTests_Chal_2
    {
        private ClaimRepo _claimRepo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepo();
            _claim = new Claim("TestClaim");

            _claimRepo.AddNewClaim(_claim);
        }


        //CREATE test
        [TestMethod]
        public void TestCreateMethod_ShouldReturnTrue()
        {
            //Arrange
            ClaimRepo claimRepo = new ClaimRepo();
            Claim claimToAdd = new Claim("TestClaim");

            //Act
            claimRepo.AddNewClaim(claimToAdd);

            //Assert
            Queue<Claim> claimDirectory = claimRepo.DisplayAllClaimsInQueue();

            bool IdIsEqual = false;
            foreach(Claim claim in claimDirectory)
            {
                if (claim.ClaimID == claimToAdd.ClaimID)
                {
                    IdIsEqual = true;
                    break;
                }
            }
            Assert.IsTrue(IdIsEqual);
        }

        //READ test
        [TestMethod]
        public void TestReadMethod_ShouldBeNotNull()
        {
            //Arrange([TestInitialize])
            //Act
            Queue<Claim> listFromQueue = _claimRepo.DisplayAllClaimsInQueue();
            //Assert
            Assert.IsNotNull(listFromQueue);
        }

        //Peek and Dequeue test
        [TestMethod]
        public void TestPeek_and_Dequeue_ShouldReturnTrue()
        {
            //Arrange([TestInitialize])
            //Act
            bool removeResult = _claimRepo.DequeueClaim();
            //Assert
            Assert.IsTrue(removeResult);
        }

        //Helper (find claim by ID) test
        [TestMethod]
        public void TestGetClaimByID()
        {
            //Arrange
            ClaimRepo claimRepo = new ClaimRepo();
            Claim claimToAdd = new Claim("TestClaimID");
            claimRepo.AddNewClaim(claimToAdd);
            //Act
            Claim claimByID = claimRepo.GetClaimByID
                (claimToAdd.ClaimID);
            //Assert
            Assert.AreEqual(claimToAdd, claimByID);
        }
    }
}
