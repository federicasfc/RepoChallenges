using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeLibrary;

namespace CafeUI
{
    public class UserInterface
    {
        private readonly MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            SeedContent();
            RunMenu();

        }

        //RunMenu Method
        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine
                (
                    "Enter the number of your menu selection:\n" +
                    "1. Show all menu items\n" +
                    "2. Find menu item by name\n" +
                    "3. Find menu item by number\n" +
                    "4. Add new items\n" +
                    "5. Update items\n" +
                    "6. Remove items\n" +
                    "7. Exit"

                );

                string userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        DisplayAllItems();
                        break;
                    case "2":
                        FindItemByName();
                        break;
                    case "3":
                        FindItemByNumber();
                        break;
                    case "4":
                        AddNewItem();
                        break;
                    case "5":
                        UpdateExistingItem();
                        break;
                    case "6":
                        RemoveExistingItem();
                        break;
                    case "7":
                        Console.WriteLine("Goodbye");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        //DisplayAllItems Method
        private void DisplayAllItems()
        {
            Console.Clear();
            List<MenuItem> listOfItems = _repo.GetAllMenuItems();

            foreach (MenuItem item in listOfItems)
            {
                PrintContent(item);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //FindItemByName Method
        private void FindItemByName()
        {
            Console.Clear();
            Console.WriteLine("What is the name of the item you're looking for?");

            string targetName = Console.ReadLine();

            MenuItem item = _repo.GetMenuItemByName(targetName);

            if (item != null)
            {
                //Content found
                PrintContent(item);
            }
            else
            {
                Console.WriteLine("Name not found");

            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


        }
        //FindItemByNumber

        private void FindItemByNumber()
        {
            Console.Clear();
            Console.WriteLine("What is the number of the item you're looking for?");

            int targetNumber = int.Parse(Console.ReadLine());

            MenuItem item = _repo.GetMenuItemByNumber(targetNumber);

            if (item != null)
            {
                PrintContent(item);
            }
            else
            {
                Console.WriteLine("number not found");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //AddNewItem Method
        private void AddNewItem()
        {
            Console.Clear();

            MenuItem item = new MenuItem();


            Console.WriteLine("Enter the item number: ");
            item.ItemNumber = int.Parse(Console.ReadLine().Trim());

            Console.WriteLine("Enter the name: ");
            item.Name = Console.ReadLine().Trim();

            Console.WriteLine("Enter the item description: ");
            item.Description = Console.ReadLine().Trim();

            Console.WriteLine("Enter the item ingredients separated by commas: ");
            item.Ingredients = Console.ReadLine().Trim().Split(',').ToList(); //I think here Trim will only remove the whitespace before the first ingredient and after the last one- not any whitespace that might be in between. In that case, may have to look into other Trims at some point later on. 

            Console.WriteLine("Enter the item price: ");
            item.Price = double.Parse(Console.ReadLine().Trim());

            _repo.AddItemToRepo(item);

        }
        //UpdateItem Method

        private void UpdateExistingItem()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the item you want to update");

            string updateTarget = Console.ReadLine();

            MenuItem item = _repo.GetMenuItemByName(updateTarget);

            MenuItem newItem = new MenuItem();

            //Inputing new info

            Console.WriteLine("Enter the item number: ");
            newItem.ItemNumber = int.Parse(Console.ReadLine().Trim());

            Console.WriteLine("Enter the name: ");
            newItem.Name = Console.ReadLine().Trim();

            Console.WriteLine("Enter the item description: ");
            newItem.Description = Console.ReadLine().Trim();

            Console.WriteLine("Enter the item ingredients separated by commas: ");
            newItem.Ingredients = Console.ReadLine().Trim().Split(',').ToList(); //Trim method - will get rid of any whitespace user inputs-- research syntax and tack on hopefully

            Console.WriteLine("Enter the item price: ");
            newItem.Price = double.Parse(Console.ReadLine().Trim());


            //Running Repo Update Method

            bool success = _repo.UpdateExistingItem(updateTarget, newItem);

            if (success)
            {
                Console.WriteLine("Content successfully updated.");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();



        }

        //RemoveItem Method

        private void RemoveExistingItem()
        {
            Console.Clear();

            //Listing all content and letting user pick one

            DisplayAllItems();

            Console.WriteLine("\n Select the number of the item you want to remove:");

            int itemSelection = int.Parse(Console.ReadLine());

            MenuItem selectedItem = _repo.GetMenuItemByNumber(itemSelection);

            //Checking for Valid Selection
            if (selectedItem != null)
            {
                if (_repo.RemoveItemFromRepo(selectedItem))
                {
                    Console.WriteLine($"{selectedItem.Name} was removed");
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                }

            }
            else
            {
                Console.WriteLine("Invalid selection");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }
        //Helper Methods

        private void PrintContent(MenuItem item)
        {
            Console.WriteLine($"Item Number: {item.ItemNumber}\n" +
            $"Name: {item.Name}\n" +
            $"Description: {item.Description}\n" +
            $"Price: {item.Price}\n" +
            $"Ingredients:"
            );
            PrintIngredientsLists(item);
            Console.WriteLine("\n\n");
        }
        private void PrintIngredientsLists(MenuItem item)
        {
            foreach (string ingredient in item.Ingredients)
            {
                Console.Write($"{ingredient}, ");
            }
        }

        //Seed Content
        private void SeedContent()
        {
            MenuItem burger = new MenuItem(1, "Burger", "Classic hamburger", new List<string> { "bread", "beef patty", "lettuce", "tomato" }, 5.50);
            MenuItem pizza = new MenuItem(2, "Pizza", "Classic slice of cheese pizza", new List<string> { "dough", "tomato sauce", "mozzarella cheese" }, 3.50);
            MenuItem coke = new MenuItem(3, "Coke", "Classic Coca Cola beverage", new List<string> { "lots of sugar", "syrup probably", "ask the company" }, 1.00);

            _repo.AddItemToRepo(burger);
            _repo.AddItemToRepo(pizza);
            _repo.AddItemToRepo(coke);
        }

    }
}