using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenges_3_Badges_REPO
{
    public class Badge
    {
        public Dictionary<int, string> doors = new Dictionary<int, string>();

        public int BadgeID { get; set; }
        public List<string> DoorsAccessible { get; set; }
        //doors.add("Door1", 1);

        public Badge() { }
        public Badge(string BadgeID) { }
        public Badge(int badgeID, List<string> doorsAccessible)
        {
            BadgeID = badgeID;
            DoorsAccessible = doorsAccessible;
        }
    }
}
