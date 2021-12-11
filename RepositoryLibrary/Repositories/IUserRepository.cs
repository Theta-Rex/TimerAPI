using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLibary.Models;

namespace RepositoryLibrary.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(int id);
        Task<User> Create(User user);
        Task Update(User user);
        Task Delete(int id);

    }
}
