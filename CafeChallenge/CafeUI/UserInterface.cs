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
            RunMenu();
            SeedContent();

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
                    "3. Add new items\n" +
                    "4. Update items\n" +
                    "5. Remove items\n" +
                    "6. Exit"

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
                        //Insert AddNewItem method
                        break;
                    case "4":
                        //Insert UpdateItem method
                        break;
                    case "5":
                        //Insert RemoveItem method
                        break;
                    case "6":
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
            } //PrintContent not working for some reason-address later.
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

        //AddNewItem Method

        //UpdateItem Method

        //RemoveItem Method


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
        }
        private void PrintIngredientsLists(MenuItem item)
        {
            foreach (string ingredient in item.Ingredients)
            {
                Console.Write(ingredient);
            }
        }

        //Seed Content
        private void SeedContent()
        {
            MenuItem burger = new MenuItem(1, "Burger", "Classic hamburger", new List<string> { "bread", "beef patty", "lettuce", "tomato" }, 5.50);
            MenuItem pizza = new MenuItem(2, "Pizza", "Classic slice of cheese pizza", new List<string> { "dough", "tomato sauce", "mozzarella cheese" }, 3.50);
            MenuItem coke = new MenuItem(3, "Coke", "Classic Coca Cola beverage", new List<string> { "lots of sugar", "syrup probably", "ask the company" }, 1.00);

            _repo.AddContentToRepo(burger);
            _repo.AddContentToRepo(pizza);
            _repo.AddContentToRepo(coke);
        }

    }
}