using System;
using NearbyFriends.Business;
using NearbyFriends.Entities;
using NearbyFriends.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NearbyFriends.Test.Tests
{
    [TestClass]
    public class FriendNearTest
    {
        [TestMethod]
        public void GivenIHaveFriends_WhenIVisitAFriendBeta_ThenIShouldKnowWhatFriendIsNear()
        {
            //arrange
            const string friendsNameThatImVisiting = "Friend Beta";
            var friendsList = HelperTest.PrepareAFriendsList_B();
            friendsList.Add(new Friend(friendsNameThatImVisiting, new Position(-1, -20)));
            var friendBusinessSut = new MyFriends(friendsList);

            //act            
            friendBusinessSut.VisitAFriend(friendsNameThatImVisiting);

            var friendsNear = friendBusinessSut.GetNearFriendsTop3();

            //assert
            Assert.AreEqual("Friend A", friendsNear[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenIHaveFriends_WhenIWantVisitAFriendSigmaAndHeDoesntExistImMyList_ThenIShouldReceiveAThrowException()
        {
            //arrange
            string friendsNameThatImVisiting = "Friend Sigma";
            var friendsList = HelperTest.PrepareAFriendsList_B();
            var friendBusinessSut = new MyFriends(friendsList);

            //act            
            friendBusinessSut.VisitAFriend(friendsNameThatImVisiting);

        }

        [TestMethod]
        public void GivenIHaveFriendsUnorderedList_WhenIVisitAFriendBeta_ThenIShouldKnowWhatFriendIsNear()
        {
            //arrange
            string friendsNameThatImVisiting = "Friend Beta";
            var friendsList = HelperTest.PrepareAFriendsList_B();
            friendsList.Add(new Friend(friendsNameThatImVisiting, new Position(25, 18)));

            //act
            var friendBusinessSut = new MyFriends(friendsList);
            friendBusinessSut.VisitAFriend(friendsNameThatImVisiting);

            var friendNear = friendBusinessSut.GetNearFriendsTop3()[0];

            //assert
            Assert.AreEqual("Friend Z", friendNear.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenIHaveFriendsList_WhenITryToGetNearFriendWithouInformWhatFriendIamVisit_ThenIShouldReceiveAThrowException()
        {
            //arrange
            var friendsList = HelperTest.PrepareAFriendsUnorderedList();
            var friendBusinessSut = new MyFriends(friendsList);

            //act
            var friendNear = friendBusinessSut.GetNearFriendsTop3()[0];

            //assert
            Assert.AreEqual("Friend K", friendNear.Name);
        }

        [TestMethod]
        public void GivenIHaveFriendsUnorderedListAndIInsertAFriendOnVisitingAt0Position_WhenIVisitAFriendOmega_ThenIShouldKnowWhatFriendIsNear()
        {
            //arrange
            var friendsList = HelperTest.PrepareAFriendsUnorderedList();

            string friendsNameThatImVisiting = "Friend Omega";
            friendsList.Insert(0, new Friend(friendsNameThatImVisiting, new Position(25, 18)));

            //act
            var friendBusinessSut = new MyFriends(friendsList);
            friendBusinessSut.VisitAFriend(friendsNameThatImVisiting);

            var friendNear = friendBusinessSut.GetNearFriendsTop3()[0];

            //assert
            Assert.AreEqual("Friend K", friendNear.Name);
        }

        [TestMethod]
        public void GivenIHaveFriendsUnorderedListAndIInsertAFriendOnVisitingAt3Position_WhenIVisitAFriendOmega_ThenIShouldKnowWhatFriendIsNear()
        {
            //arrange
            var friendsList = HelperTest.PrepareAFriendsUnorderedList();

            var friendsNameThatImVisiting = "Friend Omega";
            friendsList.Insert(3, new Friend(friendsNameThatImVisiting, new Position(25, 18)));

            //act
            var friendBusinessSut = new MyFriends(friendsList);
            friendBusinessSut.VisitAFriend(friendsNameThatImVisiting);

            var friendNear = friendBusinessSut.GetNearFriendsTop3()[0];

            //assert
            Assert.AreEqual("Friend K", friendNear.Name);
        }
    }
}
