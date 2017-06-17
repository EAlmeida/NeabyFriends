using NearbyFriends.Business;
using NearbyFriends.Entities;
using NearbyFriends.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NearbyFriends.Test.Tests
{
    /*
     * Testes:
     * 
     * 1) Cada um de seus amigos vive em uma posição específica (latitude e longitude) - para os propósitos deste problema 
     *      o mundo é plano e a latitude e a longitude são coordenadas cartesianas em um plano - e você consegue identificá-los de alguma maneira [Ok]
     * 
     * 2) Também cada amigo mora em uma posição diferente (dois amigos nunca estão na mesma latitude e longitude) [OK]
     * 
     * 3) Escreva um programa que receba a localização de cada um dos seus amigos [OK]
     * 
     * 4) para cada um deles,  indique quais são os outros três amigos mais próximos a ele [OK]
     * 
     */

    [TestClass]
    public class FriendTest
    {
        [TestMethod]
        public void GivenIWantIdentifySomeFriends_WhenIInstantiateAFriendA_ThenIShouldBeAbleToInputHisName()
        {
            var position = new Position(0, 0);
            var friendA = new Friend(position);
            var friendNameA = "Friend A";

            friendA.Name = friendNameA;

            Assert.AreEqual(friendNameA, friendA.Name);
        }

        [TestMethod]
        public void GivenIWantIdentifySomeFriends_WhenIHaveAFriendsList_ThenIShouldBeAbleToIdentifyTheFriendZ()
        {   
            //arrange
            var friendNameZ = "FriendZ";
            var friendZ = new Friend(friendNameZ ,new Position(0, 0));

            var friendsList = HelperTest.PrepareAFriendsList();            
            friendsList.Add(friendZ);

            //act
            friendZ.Name = friendNameZ;

            //assert
            Assert.IsTrue(friendsList.Count > 1);
            Assert.IsTrue(friendsList.Exists(_ => _.Name == friendNameZ));
        }
        
        [TestMethod]
        public void GivenIHaveFriends_WhenIWantVisitAFriendBeta_ThenIShouldBeAbleToDoIt()
        {
            //arrange
            var friendsNameThatImVisiting = "Friend Beta";
            var friendsList = HelperTest.PrepareAFriendsList();
            friendsList.Add(new Friend(friendsNameThatImVisiting, new Position(25, 18)));            

            //act
            var visitingFriend = new MyFriends(friendsList).VisitAFriend(friendsNameThatImVisiting);

            //assert
            var expected = friendsList.Find(_ => _.Name == friendsNameThatImVisiting);
            var expectedName = expected.Name;

            Assert.IsTrue(expectedName == visitingFriend.Name);
        }


    }
}
