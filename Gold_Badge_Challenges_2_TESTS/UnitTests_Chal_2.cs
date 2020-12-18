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


        //CREATE METHOD TEST
        [TestMethod]
        public void TestCreateMethod_ShouldReturnTrue()
        {
            //Arrange -- set up the data or controlled environment for test to run
            ClaimRepo claimRepo = new ClaimRepo();
            Claim claimToAdd = new Claim("TestClaim");

            //Act --call method to be tested
            claimRepo.AddNewClaim(claimToAdd);

            //Assert -- method has run; no write some lines to confirm it behaved as desired
            List<Claim> claimDirectory = ClaimRepo.DisplayAllClaimsInQueue();

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

        //Read



        //Peek/Take next/Remove from queue when done


        //GetClaimByID()
    }
}
