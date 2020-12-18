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


        //Take Next Claim??????
        public Claim TakeNextClaim()
        {
            return _claimQueue.Peek();
        }
        //When this option is chosen, user will be shown the next claim in queue.


        //Confirm -- "Would you like to open this claim? (y/n)"

        //"When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu."
        //// To Remove an element from the Queue:

        //Dequeue Helper method
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

        //Helper Method (for DELETE function)
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

        /*Delete claim (JOSH'S WAY)***
        public bool DeleteClaimFromQueue(string claimID)
        {
            Claim claim = GetClaimByID(claimID);

            if (claim == null)
            {
                return false;
            }

            int initialCount = _claimQueue.Count;
            _claimQueue.Dequeue(claim);

            if (initialCount > _claimQueue.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

    }
}

