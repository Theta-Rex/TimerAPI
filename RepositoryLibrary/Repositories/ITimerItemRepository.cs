using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryLibrary.Models;

namespace RepositoryLibrary.Repositories
{
    public interface ITimerItemRepository
    {
        Task<IEnumerable<TimerItem>> Get();
        Task<TimerItem> Get(int timerId);
        Task<TimerItem> Create(TimerItem timerItem);
        Task Update(TimerItem timerItem);
        Task Delete(int timerId);

    }
}
