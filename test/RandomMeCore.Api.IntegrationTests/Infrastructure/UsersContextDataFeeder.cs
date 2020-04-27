using System;
using System.Collections.Generic;
using RandomMeCore.Core;
using RandomMeCore.Core.Models;

namespace RandomMeCore.Api.IntegrationTests.Infrastructure
{
    public class UsersContextDataFeeder
    {
        public static void Feed(UsersContext dbContext)
        {

            var titles = new List<Title>()
            {
                new Title{ Value ="Mr.", CountryId = 1, Gender = Gender.M},
                new Title{ Value ="Mrs", CountryId = 1, Gender = Gender.F },
                new Title{ Value ="Miss", CountryId = 1, Gender = Gender.F },
            };

            var firstNames = new List<FirstName>()
            {
                new FirstName{ Value ="aaron", CountryId = 1, Gender = Gender.M },
                new FirstName{ Value ="adam", CountryId = 1, Gender = Gender.M},
                new FirstName{ Value ="aidan", CountryId = 1, Gender = Gender.M },
                new FirstName{ Value ="ava", CountryId = 1, Gender = Gender.F },
                new FirstName{ Value ="ayla", CountryId = 1, Gender = Gender.F },
                new FirstName{ Value ="bella", CountryId = 1, Gender = Gender.F },
            };

            var lastNames = new List<LastName>()
            {
                new LastName{ Value = "Smith", CountryId = 1},
                new LastName{ Value = "Jones", CountryId = 1},
                new LastName{ Value = "Brown", CountryId = 1},
                new LastName{ Value = "Cooper", CountryId = 1},
            };

            dbContext.Countries.Add(new Country() { Id = 1, Name = "NZ" });
            dbContext.Titles.AddRange(titles);
            dbContext.FirstNames.AddRange(firstNames);
            dbContext.LastNames.AddRange(lastNames);

            dbContext.SaveChanges();
        }
    }
}
