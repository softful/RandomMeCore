using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using RandomMeCore.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace RandomMeCore.Core.Repositories
{
    public class NameCachedRepository : INameRepository
    {
        private UsersContext usersContext;
        private IMemoryCache cache;
        private const string FirstNameCacheKey = "FIRST_NAME_KEY";
        private const string LastNameCacheKey = "LAST_NAME_KEY";
        private const string TitleCacheKey = "TITLE_KEY";
        private const string PhotoCacheKey = "PHOTO_KEY";
        private TimeSpan cacheExpiration = TimeSpan.FromMinutes(10);

        public NameCachedRepository(UsersContext usersContext, IMemoryCache cache)
        {
            this.usersContext = usersContext;
            this.cache = cache;            
        }

        public async Task<IEnumerable<FirstName>> GetFirstNames(CancellationToken cancellationToken)
        {
            return await cache.GetOrCreateAsync(FirstNameCacheKey, (entry) =>
             {
                 entry.AbsoluteExpirationRelativeToNow = cacheExpiration;
                 return usersContext.FirstNames.ToListAsync(cancellationToken);
             });
        }

        public async Task<IEnumerable<Photo>> GetPhotosByGender(Gender gender, CancellationToken cancellationToken)
        {
            return await cache.GetOrCreateAsync(PhotoCacheKey + gender.ToString(), (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = cacheExpiration;
                return usersContext.Photos.Where(w => w.Gender == gender).ToListAsync();
            });
        }

        public async Task<IEnumerable<FirstName>> GetFirstNamesByCountry(int countryId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<LastName>> GetLastNames(CancellationToken cancellationToken)
        {
            return await cache.GetOrCreateAsync(LastNameCacheKey, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = cacheExpiration;
                return usersContext.LastNames.ToListAsync(cancellationToken);
            });
        }

        public async Task<IEnumerable<LastName>> GetLastNamesByCountry(int countryId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Title>> GetTitles(CancellationToken cancellationToken)
        {
            return await cache.GetOrCreateAsync(TitleCacheKey, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = cacheExpiration;
                return usersContext.Titles.ToListAsync(cancellationToken);
            });
        }

        public async Task<IEnumerable<Title>> GetTitlesByCountry(int countryId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<NameBlock>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

    }
}
