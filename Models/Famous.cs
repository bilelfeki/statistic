using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Famous
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Follower> Followers { get; set; }

    }
}
