using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using statistique.Interfaces;
using statistique.Services;
using statistique2.DBConnextion;
using System;
using System.Collections.Generic;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace statistique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly IFollowerViewService _followerViewServie; 

        public FollowerController(IFollowerViewService followerViewServie)
        {
            _followerViewServie = followerViewServie;
        }


        [HttpGet("/followers")]
        public IEnumerable<FollowerView> getFollowers()
        {
            return _followerViewServie.GetFollowers();
        }

        [HttpPost("create")]
        public string  createFollower([FromBody] FollowerView Follower)
        {
            using(var context = new AppDbContext())
            {
               return  _followerViewServie.SaveFollower(Follower);
            }
        }

    }
}
