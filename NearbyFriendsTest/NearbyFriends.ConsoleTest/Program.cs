using System;
using System.Collections.Generic;
using System.Threading;
using NearbyFriends.Business;
using NearbyFriends.Entities;

namespace NearbyFriends.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program Nearby Friends \n");

            var friendsList = GetAFriendsList();

            PresenterFriends();

            string friendOnVisit;
            string confirmationChoice;
            GetUserChoice(out friendOnVisit, out confirmationChoice);

            while (confirmationChoice.Trim().ToUpper() != "S")
            {
                GetUserChoice(out friendOnVisit, out confirmationChoice);
            }

            try
            {
                var friendBusiness = new MyFriends(friendsList);
                friendBusiness.VisitAFriend(friendOnVisit);

                var nearFriends = friendBusiness.GetNearFriendsTop3();
                PresenterNearFriends(nearFriends);
            }
            catch (Exception)
            {
                Console.WriteLine("Occurred an error during the execution of program. Please try again.\nIf the error persist please contact the Administrator");
                Thread.Sleep(4000);
            }

            Console.WriteLine("\nEnding the program");
            Thread.Sleep(4000);
        }



        #region Private

        private static List<Friend> GetAFriendsList()
        {
            var friendsList = new List<Friend>{
                new Friend("Eduardo Almeida", new Position(-110, -80)),
                new Friend("Friend A", new Position(6, 10)),
                new Friend("Friend B", new Position(-43, -51)),
                new Friend("Friend C", new Position(15, 50)),
                new Friend("Friend D", new Position(35, 40)),
                new Friend("Friend E", new Position(-31, -19)),
                new Friend("Friend F", new Position(37, 43)),
                new Friend("Friend G", new Position(-20, -34)),
                new Friend("Friend H", new Position(140, 101)),
                new Friend("Friend I", new Position(-110, -99)),
            };
            return friendsList;
        }

        private static void PresenterFriends()
        {
            Console.WriteLine("Lista de amigos: ");

            foreach (var friend in GetAFriendsList())
            {
                Console.WriteLine(string.Format("Nome: {0} - Localização: Latitude = {1} - Longitude = {2}",
                    friend.Name,
                    friend.Position.Latitude,
                    friend.Position.Longitude
                ));
            }
            Console.WriteLine(" ");
        }

        private static void GetUserChoice(out string friendOnVisitName, out string confirmationChoice)
        {
            Console.WriteLine("Entre com o nome do amigo que você deseja visitar.");
            friendOnVisitName = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine(string.Format("Você digitou o nome: {0}. Está correto? \n Digite 's' para sim ou 'n' para não",
                friendOnVisitName));
            confirmationChoice = Console.ReadLine();
            Console.WriteLine(" ");
        }

        private static void PresenterNearFriends(List<Friend> nearFriends)
        {
            Console.WriteLine("Lista de amigos: ");

            foreach (var friend in nearFriends)
            {
                System.Console.WriteLine(string.Format("Nome: {0}", friend.Name));
            }
            Console.ReadKey();
        }

        #endregion
    }
}
