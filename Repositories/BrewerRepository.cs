using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBackend.DataContext;
using ProjectBackend.Models;

namespace ProjectBackend.Repositories
{
    public interface IBrewerRepository
    {
        Task<List<Brewer>> GetBrewers();
    }

    public class BrewerRepository : IBrewerRepository
    {
        private IBeerContext _context;
        public BrewerRepository(IBeerContext context)
        {
            _context = context;
        }

        public async Task<List<Brewer>> GetBrewers()
        {
            return await _context.Brewer.ToListAsync();
        }
    }
}
