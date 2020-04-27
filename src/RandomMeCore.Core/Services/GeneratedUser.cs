
using RandomMeCore.Core.Models;
using System;

namespace RandomMeCore.Core.Services
{
    public class GeneratedUser
    {      
        public int Id { get; internal set; }

        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public string Email { get; internal set; }

        public string Phone { get; internal set; }

        public Gender Gender { get; internal set; }

        public string Title { get; internal set; }

        public DateTime DateOfBirth { get; internal set; }

        public string PhotoUrl { get; set; }
    }
}
