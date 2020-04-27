using RandomMeCore.Core.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RandomMeCore.Core.Repositories
{
    public interface INameRepository
    {
        Task<IEnumerable<Title>> GetTitles(CancellationToken cancellationToken);

        Task<IEnumerable<Photo>> GetPhotosByGender(Gender gender, CancellationToken cancellationToken);

        Task<IEnumerable<Title>> GetTitlesByCountry(int countryId, CancellationToken cancellationToken);

        Task<IEnumerable<FirstName>> GetFirstNames(CancellationToken cancellationToken);

        Task<IEnumerable<FirstName>> GetFirstNamesByCountry(int countryId, CancellationToken cancellationToken);

        Task<IEnumerable<LastName>> GetLastNames(CancellationToken cancellationToken);

        Task<IEnumerable<LastName>> GetLastNamesByCountry(int countryId, CancellationToken cancellationToken);

    }   
}
