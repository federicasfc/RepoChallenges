using System;
using System.Collections.Generic;

namespace BadgeLibrary
{
    public class Badge
    {
        private static int TotalBadges = 0;
        //Constructor
        public Badge(List<string> doorNames, string badgeName)
        {
            BadgeId = ++TotalBadges;
            DoorNames = doorNames;
            BadgeName = badgeName;
        }

        //Properties

        public int BadgeId { get; set; }

        public List<string> DoorNames { get; set; }

        public string BadgeName { get; set; }
    }
}
