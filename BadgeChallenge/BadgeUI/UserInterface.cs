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
            RunMenu();

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
                        AddNewBadge();
                        break;
                    case "2":
                        EditBadgeDoors();
                        break;
                    case "3":
                        DisplayAllBadges();
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
        private void AddNewBadge()
        {
            Console.Clear();

            Badge badge = new Badge();

            Console.WriteLine("Enter the list of accessible doors separated by commas:");
            badge.DoorNames = Console.ReadLine().Trim().ToUpper().Split(',').ToList();

            Console.WriteLine("Enter the badge name:");
            badge.BadgeName = Console.ReadLine().Trim();

            if (_repo.AddNewBadgeToRepo(badge))
            {
                Console.WriteLine($"Badge {badge.BadgeId} successfully added.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        //EditBadge
        private void EditBadgeDoors()
        {
            Console.Clear();
            Console.WriteLine("Enter the badge id number of the badge you wish to edit:");

            int enteredNumber = int.Parse(Console.ReadLine().Trim());

            Badge badge = _repo.GetBadgeByIdNumber(enteredNumber); //maybe add an if/else to validate user input -- later ig

            Console.WriteLine($"This badge has access to doors: ");
            PrintDoorsList(badge);

            Console.WriteLine("\nWhat would you like to do?\n" +

            "1.Remove a door\n" +
            "2.Remove all doors\n" +
            "3.Add a door"
            );

            string userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":

                    Console.WriteLine("Enter the door you would like removed from badge: ");
                    string doorToBeRemoved = Console.ReadLine();

                    if (badge.DoorNames.Contains(doorToBeRemoved.Trim().ToUpper()))
                    {
                        if (_repo.RemoveDoorFromBadge(enteredNumber, doorToBeRemoved))
                        {

                            Console.WriteLine($"{doorToBeRemoved} successfully removed");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("Something went wrong");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }

                    break;
                case "2":

                    Console.WriteLine($"Are you sure you want to remove all doors from {badge.BadgeId}?\nEnter y/n");
                    string userConfirmation = Console.ReadLine();

                    if (userConfirmation.ToLower().Trim() == "y")
                    {
                        if (_repo.RemoveAllDoorsFromBadge(enteredNumber)) //Because this is relying on the SeedContent to run, BadgeRepo and its methods don't recognize that there is (kind of) content inside. So for this method, since the bool return is dependent on the listCount, it's not working.
                        {
                            Console.WriteLine($"All doors removed from badge {badge.BadgeId}");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                    }
                    else if (userConfirmation.ToLower().Trim() == "n")
                    {
                        Console.WriteLine($"No doors removed from badge {badge.BadgeId}");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();

                    }

                    break;
                case "3":

                    Console.WriteLine("Enter the door you would like to add: ");
                    string doorToBeAdded = Console.ReadLine();

                    if (_repo.AddDoorToBadge(enteredNumber, doorToBeAdded.Trim().ToUpper()))
                    {
                        Console.WriteLine($"Door successfully added to {badge.BadgeId}");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }

                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;

            }

            Console.WriteLine($"Badge {badge.BadgeId} has access to: ");
            PrintDoorsList(badge);
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();

        }


        //DisplayAllBadges

        private void DisplayAllBadges()
        {
            Console.Clear();

            Dictionary<int, Badge> dictOfBadges = _repo.GetAllBadges();

            foreach (KeyValuePair<int, Badge> badge in dictOfBadges)
            {
                Console.WriteLine($" Badge #: {badge.Key}, Door Access:");

                foreach (string door in badge.Value.DoorNames)
                {
                    Console.WriteLine($"{door}");
                }


            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        //Helper Methods

        //Print Content

        /*  private void PrintContent()
         {
             string badgeNumberLabel = "Badge #:";
             string badgeDoorsLabel = "Door Access:";
             string badgeIdNumber = badge.BadgeId.ToString();
             List<string> doorsList = badge.DoorNames;


             string FormatBadgeNumberLabel = String.Format("{0, -10}", badgeNumberLabel);
             string FormatBadgeDoorsLabel = String.Format("{0, 20}", badgeDoorsLabel);
             string FormatBadgeIdNumber = String.Format("{0, -10}", badgeIdNumber);
             string FormatBadgeDoors = String.Format("{0, 25}", doorsList);

             Console.WriteLine(FormatBadgeNumberLabel);
             Console.WriteLine(FormatBadgeDoorsLabel);
             Console.WriteLine(FormatBadgeIdNumber);
             Console.WriteLine(FormatBadgeDoors); //This is probably just going to print the fact that this is a list and not the list itself- adjust later


         } */

        private void PrintDoorsList(Badge badge)
        {
            foreach (string door in badge.DoorNames)
            {
                Console.Write($"{door} ");
            }
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