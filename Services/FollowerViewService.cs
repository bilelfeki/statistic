using statistique.Interfaces;
using statistique2.DBConnextion;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace statistique.Services
{
    public class FollowerViewService : IFollowerViewService
    {
        public List<FollowerView> GetFollowers()
        {
            var FollowerList = new List<FollowerView>();
            using (var context = new AppDbContext())
            {

                context.Followers.ToList().ForEach(elem => FollowerList.Add(new FollowerView{
                        Id=elem.Id,
                        Email=elem.Email,
                        Name =elem.Name
                        }
                    ));
            }
            return FollowerList; 
            }
       
        public string SaveFollower(FollowerView followerView)
        {
            using (var context = new AppDbContext())
            {
                //To DO :
                //if the email exist then we shouden't create the Famous 
                if (context.Famous.Where(f => f.Email == followerView.Email).Any())
                {
                    return "Email alraydy Exist";
                }
                else
                {
                    try
                    {
                        followerView.Id = Guid.NewGuid();
                        var Follower = createFollowerFromFolloerView(followerView);
                        context.Followers.Add(Follower);
                        context.SaveChanges();
                        return "successfully Famous added ";
                    }
                    catch
                    {
                        return "an Error occured while saving please try Again";
                    }
                }

            }

        }
        private Follower  createFollowerFromFolloerView(FollowerView followerView)
        {
            return new Follower 
            {
                Id = followerView.Id,
                Name = followerView.Name,
                Email = followerView.Email,
            };
        }


    }


}
