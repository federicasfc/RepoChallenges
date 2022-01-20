using System;
using System.Collections.Generic;

namespace CafeLibrary
{
    //Cafe Library is where the POCO and Repo go
    public class MenuItem
    {


        //Constructor
        public MenuItem() { } //For AddItem and UpdateItem UI methods
        public MenuItem(int itemNumber, string name, string description, List<string> ingredients, double price)
        {
            ItemNumber = itemNumber;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;

        }
        //Properties
        public int ItemNumber { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Ingredients { get; set; }

        public double Price { get; set; }


    }
}
