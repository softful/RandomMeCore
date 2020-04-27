using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RandomMeCore.Core.Extensions;
using RandomMeCore.Core.Models;
using RandomMeCore.Core.Repositories;

namespace RandomMeCore.Core.Services
{
    public class UserService : IUserService
    {
        private readonly INameRepository nameRepository;

        public UserService(INameRepository nameRepository)
        {
            this.nameRepository = nameRepository;
        }

        public async Task<IEnumerable<GeneratedUser>> GenerateRandomUsers(int limit, CancellationToken cancellationToken)
        {
            var titlesTask = nameRepository.GetTitles(cancellationToken);

            var firstNamesTask = nameRepository.GetFirstNames(cancellationToken);

            var lastNamesTask = nameRepository.GetLastNames(cancellationToken);

            await Task.WhenAll(titlesTask, firstNamesTask, lastNamesTask);
                        
            var titles = titlesTask.Result;

            var cartesianProduct = (from first in firstNamesTask.Result
                                    from last in lastNamesTask.Result
                                    select GenerateRandomUser(titles, first, last, cancellationToken)).Take(limit);

            return await Task.WhenAll(cartesianProduct);
        }

        public async Task<GeneratedUser> GenerateRandomUser(IEnumerable<Title> titles, FirstName firstName, LastName lastName, CancellationToken cancellationToken)
        {            
            return await Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var gender = firstName.Gender;

                var title = titles.Where(w => w.Gender == gender).RandomOrDefault()?.Value;              

                var email = $"{firstName.Value}_{lastName.Value}@example.com";
                var dob = DateHelper.Random(1900, 2010);

                var phone = DateTime.UtcNow.Ticks.ToString(); //sort of random string of digits based on ticks :)

                return new GeneratedUser
                {                   
                    Title = title,
                    FirstName = firstName.Value,
                    LastName = lastName.Value,
                    DateOfBirth = dob,
                    Email = email,
                    Phone = phone
                };

                //● Profile images(thumbnail for the list of users and large for getting a single user)

            });
        }
    }
}
