using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadgeLibrary
{
    public class BadgeRepository
    {
        Dictionary<int, Badge> _repo = new Dictionary<int, Badge>();


        //Methods

        //Create/ AddNewBadge
        //Probably will use Add(TKey, TValue) //_repo.Add(badge.BadgeId, badge)

        public bool AddNewBadgeToRepo(Badge badge)
        {
            int startingCount = _repo.Count;

            _repo.Add(badge.BadgeId, badge);

            return _repo.Count > startingCount;
        }

        //Read / GetAllBadges

        public Dictionary<int, Badge> GetAllBadges()
        {
            return _repo;
        }

        //Read/ GetBadgeByIdNumber

        public Badge GetBadgeByIdNumber(int badgeId)
        {
            Badge badgeRequested = _repo[badgeId];

            if (badgeRequested != null)
            {
                return badgeRequested;
            }
            else
            {

                Console.WriteLine("Invalid badge id number");
                return null;
            }

        } //Don't know if any of this is right; Feels like I'm doing something wrong, but not sure what-- maybe unit tests will enlighten.
        //Unit Test works, but still unsure about it. Gonna use it anyway.  


        //Update UpdateBadgeAccess
        // - will probably use the GetBadgeByIdNumber -- or not since it probably doesn't work the way I want it to; maybe use GetAllBadges instead 

        public bool UpdateExistingBadge(int badgeId, Badge newBadge)
        {

            Badge oldBadge = GetBadgeByIdNumber(badgeId);

            if (oldBadge != null)
            {
                oldBadge.BadgeId = newBadge.BadgeId;
                oldBadge.DoorNames = newBadge.DoorNames;
                oldBadge.BadgeName = newBadge.BadgeName;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Realized this update method is probably useless. Update/EditBadge method in UI will probably just involve calling the addmethod(int badgeId, badge.DoorNames)?

        //AddDoorToBadge Attempt -- doesn't work, can't figure it out

        public bool AddDoorToBadge(int badgeId, string newDoor)
        {
            Badge badge = GetBadgeByIdNumber(badgeId);

            int startingListCount = badge.DoorNames.Count();

            badge.DoorNames.Add(newDoor);

            return startingListCount < badge.DoorNames.Count();

        }

        //Delete / DeleteAllDoorsFromBadge --also doesn't work, also can't figure out why

        // - prompt does not specify that it wants to delete badges, just that it wants to delete all doors from a badge

        public bool RemoveDoorFromBadge(int badgeId, string doorName)
        {
            Badge badge = GetBadgeByIdNumber(badgeId);
            // _repo.Remove(badge.BadgeId,);
            return badge.DoorNames.Remove(doorName);

        }

        //For RemoveAllDoors 
        // badge.DoorNames = new List<string>(); //Overwrites List with new empty list

        public bool RemoveAllDoorsFromBadge(int badgeId)
        {

            Badge badge = GetBadgeByIdNumber(badgeId);

            int listCount = badge.DoorNames.Count();

            badge.DoorNames = new List<string>(); //Overwrites List with new empty list 


            return listCount > badge.DoorNames.Count(); //Doesn't prove that listCount is 0, but close enough for right now

        }


    }
}