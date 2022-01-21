using System;

namespace ClaimsLibrary
{
    public enum ClaimType { Car, Home, Theft }
    public class Claim
    {
        //Field
        private static int TotalClaims = 0;

        //Constructor

        public Claim() { ClaimId = ++TotalClaims; } //For AddNewClaim method in UI //method signature: name of method + parameter; constructors work as methods. With methods, as long as the method signature is different(either name is different or parameters are different), any amount of methods of the same name will be able to run simultaneously. 
                                                    //For this reason, I can set ClaimID= ++TotalClaims in both of these constructors. 
        public Claim(ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = ++TotalClaims; //++ has to be before because it will increment before taking action, will set to 1 first and then assign, instead of the other way around
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        //Properties
        public int ClaimId { get; }
        public ClaimType ClaimType { get; set; }

        public string Description { get; set; }

        public double ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid
        {
            get
            {
                if (DateOfClaim - DateOfIncident <= new TimeSpan(30, 0, 0, 0)) //Reads that DateClaim has to be <= 30 days (or 720 hours)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } //return DateOfClaim - DateOfIncident <= new TimeSpan(720, 0, 0) //This would get it to one line of code. A conditional inherently has to evaluate to a true or false, so typing out the if/else and setting the returns is redundant. Keeping it for the moment just for personal visual aid. 


        } //like IsFamilyFriendly from StreamingContent since it's dependent on the time elapsed between DateIncident and DateClaim

    }
}
