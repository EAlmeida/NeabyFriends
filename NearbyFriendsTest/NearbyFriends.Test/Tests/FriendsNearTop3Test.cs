using NearbyFriends.Business;
using NearbyFriends.Entities;
using NearbyFriends.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NearbyFriends.Test.Tests
{
    [TestClass]
    public class FriendsNearTop3Test
    {
        [TestMethod]
        public void GivenIHaveFriendsListValid_WhenIVisitAFriendZeta_ThenIShouldKnowOnlyTop3FriendsNear()
        {
            //arrange
            const string friendsNameThatImVisiting = "Friend Zeta";
            var friendsList = HelperTest.PrepareAFriendsList();
            friendsList.Add(new Friend(friendsNameThatImVisiting, new Position(25, 18)));

            var friendBusinessSut = new MyFriends(friendsList);
            friendBusinessSut.VisitAFriend(friendsNameThatImVisiting);

            //act            
            var top3FriendsNear = friendBusinessSut.GetNearFriendsTop3();

            //assert
            Assert.AreEqual(3, top3FriendsNear.Count);
        }

        [TestMethod]
        public void GivenIHaveFriendsListValid_WhenIVisitAFriendZeta_ThenIShouldKnowWhichAre3FriendsNear()
        {
            //arrange
            const string friendsNameThatImVisiting = "Friend Zeta";
            var friendsList = HelperTest.PrepareAFriendsList_B();
            friendsList.Add(new Friend(friendsNameThatImVisiting, new Position(33, 31)));

            var friendBusinessSut = new MyFriends(friendsList);
            friendBusinessSut.VisitAFriend(friendsNameThatImVisiting);

            //act            
            var top3FriendsNear = friendBusinessSut.GetNearFriendsTop3();

            //assert
            Assert.AreEqual("Friend K", top3FriendsNear[0].Name);
            Assert.AreEqual("Friend Y", top3FriendsNear[1].Name);
            Assert.AreEqual("Friend Z", top3FriendsNear[2].Name);
        }

        [TestMethod]
        public void GivenIHaveFriendsListInNegativePositions_WhenIVisitAFriendZeta_ThenIShouldKnowWhichAre3FriendsNear()
        {
            //arrange
            var friendsNameThatImVisiting = "Friend Zeta";
            var friendsList = HelperTest.PrepareAFriendsListWithNegativePositions();
            friendsList.Add(new Friend(friendsNameThatImVisiting, new Position(-40, -50)));

            var friendBusinessSut = new MyFriends(friendsList);
            friendBusinessSut.VisitAFriend(friendsNameThatImVisiting);

            var msgError = "This friend doesn't exist in the List: top3FriendsNear";

            //act            
            var top3FriendsNear = friendBusinessSut.GetNearFriendsTop3();
            var friendsExpected = friendsList.FindAll(_ => _.Name == "Friend K" ||
                                                            _.Name == "Friend W" ||
                                                            _.Name == "Friend Y");

            //assert
            CollectionAssert.Contains(top3FriendsNear, friendsExpected[0], msgError);
            CollectionAssert.Contains(top3FriendsNear, friendsExpected[1], msgError);
            CollectionAssert.Contains(top3FriendsNear, friendsExpected[2], msgError);
        }
    }
}
