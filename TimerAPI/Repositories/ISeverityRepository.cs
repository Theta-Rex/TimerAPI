using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimerAPI.Models;

namespace TimerAPI.Repositories
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
