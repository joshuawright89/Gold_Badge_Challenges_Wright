using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenges_2_REPO
{
    public class ClaimRepo
    {
        public Queue<Claim> _claimQueue = new Queue<Claim>();

        //Mgr. READ
        public Queue<Claim> DisplayAllClaimsInQueue()
        {
            return _claimQueue;
        }

        //Mgr. CREATE
        public void AddNewClaim(Claim claim)
        {
            _claimQueue.Enqueue(claim);
        }


        //Take Next Claim/Peek
        public Claim TakeNextClaim()
        {
            return _claimQueue.Peek();
        }
        
        //Helper (Dequeue claim)
        public bool DequeueClaim()
        {
            int initialCount = _claimQueue.Count;
            _claimQueue.Dequeue();
            if (_claimQueue.Count < initialCount)
            {
                return true;
            }
            return false;
        }

        //Helper (Find claim by ID)
        public Claim GetClaimByID(string claimID)
        {
            foreach (Claim claim in _claimQueue)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}

