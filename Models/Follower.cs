using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Follower
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid IdFamous { get; set; }
        public Famous YourFamous { get; set; }

    }
}
