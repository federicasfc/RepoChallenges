using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public class ClaimRepository
    {
        //Field
        private readonly Queue<Claim> _repo = new Queue<Claim>();

        //Methods

        //AddNewClaims (Create)

        public bool AddClaimToRepo(Claim claim)
        {
            int startingCount = _repo.Count;
            _repo.Enqueue(claim); //Enqueue adds an object to the end of the Queue. Link: https://docs.microsoft.com/en-us/dotnet/api/system.collections.queue.enqueue?view=net-6.0
            return _repo.Count > startingCount;
        }

        //GetAllClaimsMethod (Read)

        public Queue<Claim> GetAllClaims()
        {
            return _repo;
        }

        //GetNextClaim 

        public Claim GetNextClaim()
        {
            return _repo.Peek();
        }

        //RemoveClaim

        public bool RemoveClaimFromRepo()
        {
            int startingCount = _repo.Count;
            _repo.Dequeue();
            return _repo.Count < startingCount;
        }



    }
}