using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RandomMeCore.Core.Repositories
{
    public interface IRepository<T, K>
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
