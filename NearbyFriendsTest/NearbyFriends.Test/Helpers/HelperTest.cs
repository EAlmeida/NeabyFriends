using System.Collections.Generic;
using NearbyFriends.Entities;

namespace NearbyFriends.Test.Helpers
{
    public static class HelperTest
    {

        public static List<Friend> PrepareAFriendsList()
        {
            var friendA = new Friend("Friend A", new Position(1, 3));
            var friendZ = new Friend("Friend Z", new Position(5, 6));
            var friendY = new Friend("Friend Y", new Position(10, 9));
            var friendW = new Friend("Friend W", new Position(15, 12));
            var friendK = new Friend("Friend K", new Position(20, 15));

            var friendsList = new List<Friend> {friendA, friendZ, friendY, friendW, friendK};

            return friendsList;
        }

        public static List<Friend> PrepareAFriendsList_B()
        {
            var friendA = new Friend("Friend A", new Position(10, 5));
            var friendZ = new Friend("Friend Z", new Position(35, 20));
            var friendY = new Friend("Friend Y", new Position(40, 30));
            var friendW = new Friend("Friend W", new Position(50, 18));
            var friendK = new Friend("Friend K", new Position(30, 36));

            var friendsList = new List<Friend> {friendA, friendZ, friendY, friendW, friendK};

            return friendsList;
        }

        public static List<Friend> PrepareAFriendsUnorderedList()
        {
            var friendY = new Friend("Friend Y", new Position(10, 9));
            var friendZ = new Friend("Friend Z", new Position(5, 6));
            var friendW = new Friend("Friend W", new Position(15, 12));
            var friendA = new Friend("Friend A", new Position(1, 3));
            var friendK = new Friend("Friend K", new Position(20, 15));

            var friendsList = new List<Friend> {friendY, friendZ, friendW, friendA, friendK};

            return friendsList;
        }

        public static List<Friend> PrepareAFriendsListWithNegativePositions()
        {
            var friendA = new Friend("Friend A", new Position(-10, -15));
            var friendZ = new Friend("Friend Z", new Position(-30, -20));
            var friendY = new Friend("Friend Y", new Position(-20, -30));
            var friendW = new Friend("Friend W", new Position(-35, -42));
            var friendK = new Friend("Friend K", new Position(-25, -55));

            var friendsList = new List<Friend> {friendA, friendZ, friendY, friendW, friendK};

            return friendsList;
        }
    }
}
