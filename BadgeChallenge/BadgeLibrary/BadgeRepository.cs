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

        /*
        public bool GetBadgeByIdNumber(Badge badge)
        {
            return _repo.TryGetValue(badge.BadgeId, out badge); //Theoretically, I want this to return to me the value of badge located at the BadgeId. But, I would it would be nice to be able to have my parameter be the badgeId(not allowed). Because right now, I don't have a way of specifying which badge I want returned...I think.
        } //Don't think I'm doing this right. Completely misunderstood function of TryGetValue - I think all it actually does is confirm or deny whether a certain key within the dictionary exists- won't actually return value- unless that's what the "out" does */

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

        public void UpdateBadge()
        {

        }


        //Delete / DeleteAllDoorsFromBadge
        // - prompt does not specify that it wants to delete badges, just that it wants to delete all doors from a badge
        // - will probably use either the GetAllBadges or the GetBadgeByIdNumber

    }
}