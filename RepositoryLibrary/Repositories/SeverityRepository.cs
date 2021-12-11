namespace RepositoryLibrary.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ModelsLibary.Models;

    public class SeverityRepository : ISeverityRepository
    {
        private readonly TimerItemContext context;

        public SeverityRepository(TimerItemContext context)
        {
            this.context = context;
        }

        public async Task<Severity> Create(Severity severity)
        {
            this.context.Severitys.Add(severity);
            await this.context.SaveChangesAsync();

            return severity;
        }

        public async Task Delete(int id)
        {
            var severityToDelete = await this.context.Severitys.FindAsync(id);
            this.context.Severitys.Remove(severityToDelete);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Severity>> Get()
        {
            return await this.context.Severitys.ToListAsync();
        }

        public async Task<Severity> Get(int id)
        {
            return await this.context.Severitys.FindAsync(id);
        }

        public async Task Update(Severity severity)
        {
            this.context.Entry(severity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }
    }
}
