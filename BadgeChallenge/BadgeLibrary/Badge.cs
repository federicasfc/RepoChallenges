using System;
using System.Collections.Generic;

namespace BadgeLibrary
{
    public class Badge
    {
        private static int TotalBadges = 0;
        //Constructor
        public Badge() { BadgeId = ++TotalBadges; } //For AddNewBadge method in UI (ensures that id number is set correctly, otherwise is set to 0);
        public Badge(List<string> doorNames, string badgeName)
        {
            BadgeId = ++TotalBadges; //Not my original idea; Copied from Josh's fullstack app code along from the end of CodingFoundations
            DoorNames = doorNames;
            BadgeName = badgeName;
        }

        //Properties

        public int BadgeId { get; set; }

        public List<string> DoorNames { get; set; }

        public string BadgeName { get; set; }
    }
}
