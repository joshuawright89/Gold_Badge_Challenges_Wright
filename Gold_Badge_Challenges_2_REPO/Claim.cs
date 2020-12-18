using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenges_2_REPO
{
    public enum ClaimType
    {
        Auto = 1,
        Home,
        Theft
    }

    public class Claim
    {
        public string ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }

        public Claim(string claimID, ClaimType typeOfClaim, string claimDescription, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            ClaimDescription = claimDescription;
            ClaimAmount = (decimal)claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

        public Claim(string claimID) { }
    }
}
