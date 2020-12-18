using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gold_Badge_Challenges_3_Badges_REPO;
using System;
using System.Collections.Generic;

namespace Gold_Badge_Challenges_3_Badges_TESTS
{
    [TestClass]
    public class UnitTests_Chal_3
    {
        private BadgeRepo _badgeRepo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepo();
            _badge = new Badge("TestBadge");

            _badgeRepo.CreateNewBadge(_badge);
        }

        //CREATE test
        [TestMethod]
        public void TestCreateMethod_ShouldReturnTrue()
        {
            //ARRANGE
            BadgeRepo badgeRepo = new BadgeRepo();
            Badge badgeToAdd = new Badge("TestBadge");
            
            //Act
            badgeRepo.CreateNewBadge(badgeToAdd);

            //Assert
            List<Badge> badgeDirectory = badgeRepo.GetDirectory();

            bool IdIsEqual = false;
            foreach (Badge badge in badgeDirectory)
            {
                if (badge.BadgeID == badgeToAdd.BadgeID)
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
            List<Badge> listFromRepo = _badgeRepo.GetDirectory();

            //Assert
            Assert.IsNotNull(listFromRepo);
        }

        //UPDATE test


        //HELPER (find badge by ID) test
        [TestMethod]
        public void FindBadgeByID()
        {
            //Arrange
            BadgeRepo badgeRepo = new BadgeRepo();
            Badge badgeToAdd = new Badge("TestBadge");
            badgeRepo.CreateNewBadge(badgeToAdd);

            //Act
            Badge badgeByID = badgeRepo.FindBadgeByID(badgeToAdd.BadgeID);

            //Assert
            Assert.AreEqual(badgeToAdd, badgeByID);
        }
    }
}
