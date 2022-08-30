using System.Collections.Generic;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace statistique.Interfaces
{
    public interface IFollowerViewService
    {
        public string SaveFollower(FollowerView followerView);
        public List<FollowerView> GetFollowers();


    }
}
