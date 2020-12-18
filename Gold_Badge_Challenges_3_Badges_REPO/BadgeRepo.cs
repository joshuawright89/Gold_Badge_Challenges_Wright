using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenges_3_Badges_REPO
{
    public class BadgeRepo
    {
        public List<Badge> _badgeDirectory = new List<Badge>();

        //CREATE
        public void CreateNewBadge(Badge badge)
        {
            _badgeDirectory.Add(badge);
        }

        //READ
        public List<Badge> GetDirectory()
        {
            return _badgeDirectory;
        }

        //UPDATE
        public bool UpdateBadge(int originalBadgeID, Badge newBadge)
        {
            //Find badge
            Badge oldBadge = FindBadgeByID(originalBadgeID);

            //Update badge
            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.DoorsAccessible = newBadge.DoorsAccessible;

                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER (find by ID)
        public Badge FindBadgeByID(int badgeID)
        {
            foreach (Badge badge in _badgeDirectory)
            {
                if (badge.BadgeID == badgeID)
                {
                    return badge;
                }
            }
            return null;
        }

    }
}
