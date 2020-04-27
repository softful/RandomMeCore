using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RandomMeCore.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<GeneratedUser>> GenerateRandomUsers(int limit, CancellationToken cancellationToken);
    }
}
