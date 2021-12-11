namespace RepositoryLibrary.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ModelsLibary.Models;

    public class UserRepository : IUserRepository
    {
        private readonly TimerItemContext context;

        public UserRepository(TimerItemContext context)
        {
            this.context = context;
        }

        public async Task<User> Create(User user)
        {
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return user;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await this.context.Users.FindAsync(id);
            this.context.Users.Remove(userToDelete);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await this.context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await this.context.Users.FindAsync(id);
        }

        public async Task Update(User user)
        {
            this.context.Entry(user).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }
    }
}
