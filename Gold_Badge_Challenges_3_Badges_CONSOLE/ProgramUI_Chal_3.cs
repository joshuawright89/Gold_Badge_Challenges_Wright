using Gold_Badge_Challenges_3_Badges_REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenges_3_Badges_CONSOLE
{
    public class ProgramUI_Chal_3
    {
        public BadgeRepo _badgeRepo = new BadgeRepo();

        //RUN
        public void Run()
        {
            SeedData();
            while (Menu())
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Goodbye!\n" +
                "Press an key to exit...");
            Console.ReadKey();
        }

        //SeedData
        private void SeedData()
        {

        }

        //Menu
        private bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Employee Badge Manager\n\n" +
                "Please select an option:\n" +
                "[1] Create a badge\n" +
                "[2] Display all existing badges\n" +
                "[3] Update an existing badge\n" +
                "[0] Exit Badge Mgr.");

            switch (Console.ReadLine())
            {
                case "1":
                    //Create badge
                    CreateNewBadge();
                    break;
                case "2":
                    //Display all
                    DisplayAllBadges();
                    break;
                case "3":
                    //Update
                    UpdateExistingBadge();
                    break;
                case "0":
                    //Exit
                    return false;
                default:
                    Console.WriteLine("Please enter a valid response (0-3)");
                    break;
            }
            return true;
        }

        //CREATE
        public void CreateNewBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter a new Badge ID.");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter first door this badge may access.");

        }
        //DISPLAY
        public void DisplayAllBadges()
        {

        }
        //UPDATE
        public void UpdateExistingBadge()
        {

        }




    }
}
