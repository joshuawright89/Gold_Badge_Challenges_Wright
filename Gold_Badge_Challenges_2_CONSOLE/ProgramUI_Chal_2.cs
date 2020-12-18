using Gold_Badge_Challenges_2_REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenges_2_CONSOLE
{
    class ProgramUI_Chal_2
    {
        public ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            SeedData();
            while (Menu())
            {
                Console.WriteLine("Press a key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Press any key to confirm exit.");
            Console.ReadKey();
        }

        //SEED helper
        private void SeedData()
        {
            var claim1 = new Claim("1", ClaimType.Auto, "Car accident on 465", 400.00, new DateTime(2018,4,25), new DateTime(2018,4,27), true);
            var claim2 = new Claim("2", ClaimType.Home, "House fire in kitchen", 4000.00, new DateTime(2018,4,11), new DateTime(2018,4,12), true);
            var claim3 = new Claim("3", ClaimType.Theft, "Stolen pancakes!", 4.00, new DateTime(2018,4,27), new DateTime(2018,6,1), false);
            _claimRepo.AddNewClaim(claim1);
            _claimRepo.AddNewClaim(claim2);
            _claimRepo.AddNewClaim(claim3);
        }

        //MENU UI
        private bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Claims access center.\n\n" +
                "Select an option using its associated [option number].\n" +
                "[1] Display all claims\n" +
                "[2] Take next claim in queue\n" +
                "[3] Add a new claim to queue\n" +
                "[0] Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    //Display
                    DisplayAllClaims();
                    break;
                case "2":
                    //Peek
                    TakeNextClaim();
                    break;
                case "3":
                    //Add new
                    CreateNewClaim();
                    break;
                case "0":
                    //Exit
                    return false;
                default:
                    Console.WriteLine("Enter a valid option number (0-3)");
                    break;
            }
            return true;
        }

        //CREATE function
        private void CreateNewClaim()
        {
            Claim newClaim = new Claim();

            Console.Clear();
            Console.WriteLine("Type of claim: Home, Auto, or Theft?\n" +
                "[1] Auto\n" +
                "[2] Home\n" +
                "[3] Theft");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newClaim.TypeOfClaim = (ClaimType)typeAsInt;

            /*
             * Auto = 1,
               Home,
               Theft
            */

            Console.WriteLine("Assign a claim ID# to this claim.");
            newClaim.ClaimID = Console.ReadLine();

            Console.WriteLine("Give a brief description for this claim:");
            newClaim.ClaimDescription = Console.ReadLine();

            Console.WriteLine("Give an amount for the claim(round up to nearest dollar):");
            newClaim.ClaimAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("What was the date of the incident? (format: MO/DA/YEAR)");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("On what date was the claim made?");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Was this claim made within 30 days of incident? y/n?");
            newClaim.IsValid = GetYesOrNo();

            _claimRepo.AddNewClaim(newClaim);
        }

        //Display all claims
        private void DisplayAllClaims()
        {
            Console.Clear();
            var allClaims = _claimRepo.DisplayAllClaimsInQueue();
            foreach (var claim in allClaims)
            {
                DisplayClaim(claim);
            }
            Console.WriteLine();
        }

        //Display Helper
        private void DisplayClaim(Claim claim)
        {
            Console.WriteLine($"\tClaim ID: {claim.ClaimID}\n" +
                $"\tType: {claim.TypeOfClaim}\n" +
                $"\tDescription: {claim.ClaimDescription}\n" +
                $"\tAmount: {claim.ClaimAmount}\n" +
                $"\tDate of Incident: {claim.DateOfIncident.ToString("MM/dd/yyyy")}\n" +
                $"\tDate of Claim: {claim.DateOfClaim.ToString("MM/dd/yyyy")}\n" +
                $"\tValid? {claim.IsValid}\n");
        }


        //Peek function
        private void TakeNextClaim()
        {
            Claim claim = _claimRepo.TakeNextClaim();
            DisplayClaim(claim);
            DequeueClaim();
        }

        //Dequeue function
        private void DequeueClaim()
        {
            Console.WriteLine("Are you ready to remove this claim? (y/n)");
            if (GetYesOrNo())
            {
                if (_claimRepo.DequeueClaim())
                {
                    Console.WriteLine("The claim was successfully removed.");
                }
                else
                {
                    Console.WriteLine("The claim could not be removed.");
                }
            }
        }

        //Yes/No helper
        private bool GetYesOrNo()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        return false;
                }
                Console.WriteLine("Enter 'y' for yes, or 'n' for no.");
            }
        }
    }
}
