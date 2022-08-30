using statistique.Interfaces;
using statistique2.DBConnextion;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace statistique.Services
{
    public class FamousViewService : IFamousViewService
    {
        public string SaveFamous(FamousView FamousView)
        {
            using (var context = new AppDbContext())
            {
                //To DO :
                //if the email exist then we shouden't create the Famous 
                if (context.Famous.Where(f => f.Email == FamousView.Email).Any())
                {
                    return "Email alraydy Exist";
                }
                else
                {
                    try
                    {
                        FamousView.Id = Guid.NewGuid();
                        var Famous = createFamousFromFamousView(FamousView);
                        context.Famous.Add(Famous);
                        context.SaveChanges();
                        return "successfully Follower added ";
                    }
                    catch
                    {
                        return "an Error occured while saving please try Again";
                    }

                }
            }
        }
        public List<FamousView> GetAllFamous()
        {
            var Famous = new List<FamousView>();

            using (var context = new AppDbContext())
            {
                context.Famous.ToList().ForEach(elem =>
               {
                   Famous.Add(new FamousView
                   {
                       Id = elem.Id,
                       Email = elem.Email,
                       Name = elem.Name
                   });
               }
               ); 
            }
            return Famous; 
        }
        private Famous createFamousFromFamousView(FamousView Famous)
        {
            return new Famous
            {
                Id = Famous.Id,
                Name = Famous.Name,
                Email = Famous.Email,
            } ;
        }
    }
}