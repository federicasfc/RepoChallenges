using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BadgeLibrary;

namespace BadgeUI
{
    public class UserInterface
    {
        //Field

        private readonly BadgeRepository _repo = new BadgeRepository();

        //Run Method

        public void Run()
        {
            SeedContent();

        }

        //RunMenu method
        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine
                (
                    "Enter the number of your desired action:\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit"
                );

                string userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        //AddNewBadge
                        break;
                    case "2":
                        //EditBadge
                        break;
                    case "3":
                        //DisplayAllBadges
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

            }
        }

        //AddNewBadge

        //EditBadge

        //DisplayAllBadges

        private void DisplayAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> dictOfBadges = _repo.GetAllBadges();

            foreach (KeyValuePair<int, Badge> badge in dictOfBadges)
            {

            }
        }

        //Helper Methods

        //Print Content

        private void PrintContent(Badge badge)
        {
            string badgeNumberLabel = "Badge #:";
            string badgeDoorsLabel = "Door Access:";
            string badgeId = badge.BadgeId.ToString();
            List<string> doorsList = badge.DoorNames;


            string FormatBadgeNumberLabel = String.Format("{0, -10}", badgeNumberLabel);
            string FormatBadgeDoorsLabel = String.Format("{0, 20}", badgeDoorsLabel);
            string FormatBadgeIdNumber = String.Format("{0, -10}", badgeId);
            string FormatBadgeDoors = String.Format("{0, 25}", doorsList);

            Console.WriteLine(FormatBadgeNumberLabel);
            Console.WriteLine(FormatBadgeDoorsLabel);
            Console.WriteLine(FormatBadgeIdNumber);
            Console.WriteLine(FormatBadgeDoors); //This is probably just going to print the fact that this is a list and not the list itself- adjust later


        }

        //Seed Content

        private void SeedContent()
        {
            Badge badgeOne = new Badge(new List<string> { "A1", "A2", "A3", "A4" }, "NameOne");
            Badge badgeTwo = new Badge(new List<string> { "B1", "B2", "B3", "B4" }, "NameTwo");
            Badge badgeThree = new Badge(new List<string> { "C1", "C2", "C3", "C4" }, "NameThree");
            Badge badgeFour = new Badge(new List<string> { "D1", "D2", "D3", "D4" }, "NameFour");

            _repo.AddNewBadgeToRepo(badgeOne);
            _repo.AddNewBadgeToRepo(badgeTwo);
            _repo.AddNewBadgeToRepo(badgeThree);
            _repo.AddNewBadgeToRepo(badgeFour);

        }
    }
}