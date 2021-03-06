using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeLibrary
{
    public class MenuRepository
    {
        //Field
        private readonly List<MenuItem> _repo = new List<MenuItem>();

        //Eventually here we need the methods "CRUD"

        //Create
        public bool AddItemToRepo(MenuItem item)
        {
            int startingCount = _repo.Count;
            _repo.Add(item);
            return _repo.Count > startingCount;
        }

        //Read / Get All

        public List<MenuItem> GetAllMenuItems()
        {
            return _repo;
        }

        //Maybe a GetByName 
        public MenuItem GetMenuItemByName(string name)
        {
            foreach (MenuItem target in _repo)
            {
                if (target.Name.ToLower() == name)
                {
                    return target;
                }
            }
            return null;

        }

        //GetByItemNumber
        public MenuItem GetMenuItemByNumber(int itemNumber)
        {
            foreach (MenuItem target in _repo)
            {
                if (target.ItemNumber == itemNumber)
                {
                    return target;
                }
            }
            return null;
        }

        //Update 
        public bool UpdateExistingItem(string originalName, MenuItem newItem)
        {
            MenuItem oldItem = GetMenuItemByName(originalName);

            if (oldItem != null)
            {
                oldItem.ItemNumber = newItem.ItemNumber;
                oldItem.Name = newItem.Name;
                oldItem.Description = newItem.Description;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;

                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete

        public bool RemoveItemFromRepo(MenuItem existingItem)
        {
            return _repo.Remove(existingItem);
        }


    }
}