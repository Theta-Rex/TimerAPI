using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryLibrary.Models;

namespace RepositoryLibrary.Repositories
{
    public class SeverityRepository : ISeverityRepository
    {
        private readonly TimerItemContext _context;

        public SeverityRepository(TimerItemContext context)
        {
            _context = context;
        }

        public async Task<Severity> Create(Severity severity)
        {
            _context.Severitys.Add(severity);
            await _context.SaveChangesAsync();

            return severity;
        }

        public async Task Delete(int id)
        {
            var severityToDelete = await _context.Severitys.FindAsync(id);
            _context.Severitys.Remove(severityToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Severity>> Get()
        {
            return await _context.Severitys.ToListAsync();
        }

        public async Task<Severity> Get(int id)
        {
            return await _context.Severitys.FindAsync(id);
        }

        public async Task Update(Severity severity )
        {
            _context.Entry(severity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
