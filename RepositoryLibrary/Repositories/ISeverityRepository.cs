namespace RepositoryLibrary.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ModelsLibary.Models;

    public interface ISeverityRepository
    {
        Task<IEnumerable<Severity>> Get();

        Task<Severity> Get(int id);

        Task<Severity> Create(Severity severity);

        Task Update(Severity severity);

        Task Delete(int id);
    }
}
