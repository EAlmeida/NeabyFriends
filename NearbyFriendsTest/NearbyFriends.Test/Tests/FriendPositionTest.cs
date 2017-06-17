using System;
using System.Collections.Generic;
using NearbyFriends.Business;
using NearbyFriends.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NearbyFriends.Test.Tests
{
    [TestClass]
    public class FriendPositionTest
    {
        [TestMethod]
        public void GivenIWantCreateAFriendObject_WhenIInstantiateIt_ThenIShouldBeAbleToInputHisPositionLatitude10Longitude5()
        {
            //arrange
            const int latitude = 10;
            const int longitude = 5;
            var specificPosition = new Position(latitude, longitude);

            //act
            var friend = new Friend(specificPosition);

            //assert
            Assert.AreEqual(latitude, friend.Position.Latitude);
            Assert.AreEqual(longitude, friend.Position.Longitude);
        }

        [TestMethod]
        public void GivenIWantCreateAFriendObject_WhenIInstantiateIt_ThenIShouldBeAbleToInputHisPositionLatitude7700Longitude19()
        {
            //arrange
            const int latitude = 7700;
            const int longitude = 19;
            var specificPosition = new Position(latitude, longitude);

            //act
            var friend = new Friend(specificPosition);

            //assert
            Assert.AreEqual(latitude, friend.Position.Latitude);
            Assert.AreEqual(longitude, friend.Position.Longitude);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenIWantCreateTwoFriendsObjects_WhenTheyLiveInTheSamePosition_ThenIShouldReceiveAThrowExceptionAtTheSecondOne()
        {
            var positionA = new Position(150, 100);
            var positionB = positionA;

            var friendList = new List<Friend>()
            {
                new Friend(positionA),
                new Friend(positionB)
            };

            // ReSharper disable once UnusedVariable
            var myFriends = new MyFriends(friendList);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenIWantCreateThreeFriendsObjects_WhenTheyFirstAndLastOneLiveInTheSamePosition_ThenIShouldReceiveAThrowException()
        {
            var positionA = new Position(150, 100);
            var positionB = new Position(753, 42);
            var positionC = positionA;

            var friendList = new List<Friend>()
            {
                new Friend(positionA),
                new Friend(positionB),
                new Friend(positionC)
            };

            // ReSharper disable once UnusedVariable
            var myFriends = new MyFriends(friendList);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenIWantCreateFourFriendsObjects_WhenTwoOfThemHavePositionEqualsZero_ThenIShouldReceiveAThrowException()
        {
            var positionA = new Position(150, 100);
            var positionB = new Position(0, 0);
            var positionC = new Position(35, 55);
            var positionD = positionB;

            var friendList = new List<Friend>()
            {
                new Friend(positionA),
                new Friend(positionB),
                new Friend(positionC),
                new Friend(positionD)
            };

            // ReSharper disable once UnusedVariable
            var myFriends = new MyFriends(friendList);
        }

        [TestMethod]
        public void GivenIWantCreateFourFriendsObjects_WhenTwoOfThemHavePositionLatitudeEqualsZeroAndLongitudeDifferent_ThenIShouldNotReceiveAThrowException()
        {
            var positionA = new Position(150, 100);
            var positionB = new Position(0, 10);
            var positionC = new Position(35, 55);
            var positionD = new Position(0, 300);

            var friendList = new List<Friend>()
            {
                new Friend(positionA),
                new Friend(positionB),
                new Friend(positionC),
                new Friend(positionD)
            };

            // ReSharper disable once UnusedVariable
            var myFriends = new MyFriends(friendList);
        }

        [TestMethod]
        public void GivenIWantCreateFourFriendsObjects_WhenTwoOfThemHavePositionLongitudeEqualsZeroAndLatitudeDifferent_ThenIShouldNotReceiveAThrowException()
        {
            var positionA = new Position(150, 0);
            var positionB = new Position(77, 10);
            var positionC = new Position(35, 55);
            var positionD = new Position(99, 0);

            var friendList = new List<Friend>()
            {
                new Friend(positionA),
                new Friend(positionB),
                new Friend(positionC),
                new Friend(positionD)
            };

            // ReSharper disable once UnusedVariable
            var myFriends = new MyFriends(friendList);
        }

    }
}
