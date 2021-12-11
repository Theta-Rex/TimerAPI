using System.Collections.Generic;
using System.Threading.Tasks;
using ModelsLibary.Models;

namespace RepositoryLibrary.Repositories
{
    public interface ISeverityRepository
    {
        Task<IEnumerable<Severity>> Get();
        Task<Severity> Get(int id);
        Task<Severity> Create(Severity severity);
        Task Update(Severity severity);
        Task Delete(int id);

    }
}
