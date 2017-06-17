using System;
using System.Collections.Generic;
using System.Linq;
using NearbyFriends.Entities;

namespace NearbyFriends.Business
{
    //FriendsBusiness
    public class MyFriends
    {
        private List<Friend> _friends;
        private Friend _friendOnVisit;

        public MyFriends(List<Friend> friends)
        {
            _friends = friends;

            VerifyIfEachFriendAreInDifferentPosition();
        }

        public Friend VisitAFriend(string friendsNameThatImVisiting)
        {
            _friendOnVisit = _friends.FirstOrDefault(_ => _.Name == friendsNameThatImVisiting);

            if (_friendOnVisit == null)
                throw new Exception(string.Format("Your friend's list not contain this name: {0}", friendsNameThatImVisiting));

            return _friendOnVisit;
        }

        public List<Friend> GetNearFriendsTop3()
        {
            if (_friendOnVisit == null)
                throw new Exception("You need inform which friend you are visiting.");

            var myActualPosition = _friendOnVisit.Position;
            var distanceBetweenMyFriendsAndMe = CalculateDistanceBetweenMyFriendsAndMe(myActualPosition)
                                                .OrderBy(_ => _.Value)
                                                .Take(3);

            return distanceBetweenMyFriendsAndMe.Select(item => _friends.ElementAt(item.Key)).ToList();
        }


        #region Private Methods

        private void VerifyIfEachFriendAreInDifferentPosition()
        {
            _friends = _friends.OrderBy(_ => _.Position.Latitude).ToList();

            int? lastLatitude = null;
            for (var i = 0; i < _friends.Count; i++)
            {
                //Here I Gave an Id, such as a Identity from DataBase, to Identify easier.
                _friends[i].Id = i;

                if (lastLatitude.HasValue && _friends[i].Position.Latitude.Equals(lastLatitude))
                    ValidateLongitude(lastLatitude);

                lastLatitude = _friends[i].Position.Latitude;
            }
        }

        private void ValidateLongitude(int? lastLatitude)
        {
            var friendsSameLatitude = _friends.Where(_ => _.Position.Latitude == lastLatitude)
                                      .OrderBy(_ => _.Position.Longitude)
                                      .ToList();

            int? lastLongitude = null;
            for (var i = 0; i < friendsSameLatitude.Count(); i++)
            {
                if (lastLongitude.HasValue && friendsSameLatitude[i].Position.Longitude.Equals(lastLongitude))
                    throw new Exception("Already exists a friend with this Localization!");

                lastLongitude = friendsSameLatitude[i].Position.Longitude;
            }
        }

        private Dictionary<int, double> CalculateDistanceBetweenMyFriendsAndMe(Position myActualPosition)
        {
            var distanceBetweenMyFriendAndMe = new Dictionary<int, double>();

            foreach (var friend in _friends)
            {
                if (friend == _friendOnVisit)
                    continue;

                var friendPosition = friend.Position;

                var pythagoreanTheoremPartX = Math.Pow((myActualPosition.Latitude - friendPosition.Latitude), 2);
                var pythagoreanTheoremPartY = Math.Pow((myActualPosition.Longitude - friendPosition.Longitude), 2);
                var pythagoreanTheoremPartFinal = Math.Sqrt(pythagoreanTheoremPartX + pythagoreanTheoremPartY);

                distanceBetweenMyFriendAndMe.Add(friend.Id, pythagoreanTheoremPartFinal);
            }
            return distanceBetweenMyFriendAndMe;
        }

        #endregion

    }
}
