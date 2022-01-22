using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsLibrary;

namespace ClaimsUI
{
    public class UserInterface
    {
        //Field
        private readonly ClaimRepository _repo = new ClaimRepository();


        //Run Method- will include SeedContent and RunMenu (in that order lol)
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
                    "Enter the number of your selection:\n" +
                    "1. See all claims\n" +
                    "2. Handle next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit"
                );

                string userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        DisplayAllClaims();
                        break;
                    case "2":
                        HandleClaims();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        //DisplayAllClaims

        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _repo.GetAllClaims();

            foreach (Claim claim in queueOfClaims)
            {
                PrintContent(claim);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        //HandleClaims
        //  - Somwhere in here there will probably be a loop (or maybe no loop, just call GetNextClaim) with an if/else nested inside
        //  - Within the if(user presses y), Dequeue method will likely be necessary -call RemoveClaimFromRepo method
        //  - or else if(user presses n) that will go back to main menu, leaving else for invalid input)

        private void HandleClaims()
        {
            bool isRunning = true;
            while (isRunning)
            {

                Console.Clear();

                Claim nextClaim = _repo.GetNextClaim();
                PrintContent(nextClaim);

                Console.WriteLine("Do you want to handle this claim now(y/n)?");

                string userResponse = Console.ReadLine();
                if (userResponse == "y")
                {
                    Console.Clear();
                    _repo.RemoveClaimFromRepo();
                    Console.WriteLine("Claim removed from queue");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else if (userResponse == "n")
                {
                    Console.Clear();
                    Console.WriteLine("Claim is still active");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    isRunning = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();

                }
            }

        }



        //AddNewClaim

        private void AddNewClaim()
        {
            Console.Clear();

            Claim claim = new Claim();

            //ClaimId handled automatically

            //ClaimType

            Console.WriteLine(
                "Select the claim type:\n" +
                "1: Car\n" +
                "2: Home\n" +
                "3: Theft\n"
                );

            string claimTypeSelection = Console.ReadLine();

            switch (claimTypeSelection)
            {
                case "1":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;

            }

            //ClaimDescription
            Console.Write("Enter the claim description: ");
            claim.Description = Console.ReadLine().Trim();

            //ClaimAmount
            Console.Write("Enter the claim amount: ");
            claim.ClaimAmount = double.Parse(Console.ReadLine().Trim());

            //DateOfIncident

            Console.Write("Enter the date of the incident as mm/dd/yyyy: ");
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine().Trim());

            //DateOfClaim

            Console.Write("Enter the date of the claim as mm/dd/yyyy: ");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine().Trim());

            //IsValid handled automatically
            Console.Write($"Claim is valid: {claim.IsValid}");

            _repo.AddClaimToRepo(claim);

        }

        //Helper Methods:

        //PrintContent 
        private void PrintContent(Claim claim)
        {
            string[] claimPropertyLabels = { "Claim Id:", "Claim Type:", "Claim Description:", "Claim Amount:", "Date of Incident:", "Date of Claim:", "IsValid:" };
            string[] claimProperties = { $"{claim.ClaimId}", $"{ claim.ClaimType }", $"{ claim.Description }", $"{ claim.ClaimAmount }", $"{ claim.DateOfIncident }", $"{ claim.DateOfClaim }", $"{ claim.IsValid }" };


            string FormatCPLArray = String.Format("{0, -9} {1, -9} {2, -24} {3, -13} {4, -20} {5, -20} {6, -13}", claimPropertyLabels);
            string FormatCArray = String.Format("{0, -9} {1, -11} {2, -24} {3, -13} {4, -20} {5, -20} {6, -10}", claimProperties);

            Console.WriteLine(FormatCPLArray);
            //Console.WriteLine("\n");
            Console.WriteLine(FormatCArray);
            Console.WriteLine("\n");


            //Drawbacks to the way this is formatted: 
            //  - longer descriptions will inevitably throw everything out of order
            //  - I think that unless I separate each property into its own variable and String.Format each individually, I cannot change how an individual one is formatted. In this case, it means that I can't stop the time printing along with the date...
            //  - Because of the way I loop through PrintContent in the display method, this will print out the ClaimPropertyLabels each time it prints out a claim. I don't hate this, but it's potentially less readable and doesn't match the prompt.

            //Possible fixes (May come back to in time):
            //  - not sure on how to account for long descriptions as Console width is set. If I could change Console width, everything could appear on the same line 
            //  - Could refactor all of this and create individual variables for each property and each propertyLabel and String.Format them individually instead of String.Formatting the array (more lines of code, but easier to adjust formatting if needed)
            //  - Could separate out PrintContent into PrintPropertyLabels and PrintClaimInfo, call both in DisplayAllClaims, and only loop through PrintClaimInfo- this way the PropertyLabels would match the prompt and only print once.

            //OR!!! could potentially create separate variables for each of the DateTime properties, and then just interpolate the new formatted variables into the array!!! Could work...
            //Not sure if it will let me String.Format the same thing twice...unless it would count the first one as DateTime.Format(or something) and not incorporate String.Format at all yet. Need to explore further.

        }

        //SeedContent
        private void SeedContent()
        {
            Claim claimOne = new Claim(ClaimType.Home, "Tree fell on roof", 5000.00, new DateTime(2022, 01, 15), new DateTime(2022, 01, 20));
            Claim claimTwo = new Claim(ClaimType.Car, "Accident damaged bumper", 3000.00, new DateTime(2021, 11, 12), new DateTime(2021, 11, 23));
            Claim claimThree = new Claim(ClaimType.Theft, "Tv stolen", 500.00, new DateTime(2021, 12, 25), new DateTime(2022, 01, 06));
            Claim invalidClaim = new Claim(ClaimType.Home, "Heating system broke", 7000.00, new DateTime(2021, 10, 30), new DateTime(2021, 12, 05));

            _repo.AddClaimToRepo(claimOne);
            _repo.AddClaimToRepo(claimTwo);
            _repo.AddClaimToRepo(claimThree);
            _repo.AddClaimToRepo(invalidClaim);

        }
    }
}
