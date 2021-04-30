using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBackend.DataContext;
using ProjectBackend.Models;

namespace ProjectBackend.Repositories
{
    public interface IBeerRepository
    {
        Task<List<Beer>> GetBeers();
        Task<Beer> GetBeer(int beerId);
    }

    public class BeerRepository : IBeerRepository
    {
        private IBeerContext _context;
        public BeerRepository(IBeerContext context)
        {
            _context = context;
        }

        public async Task<List<Beer>> GetBeers()
        {
            return await _context.Beers.Include(b => b.Bitterness).Include(b => b.Brewer).Include(b => b.BeerUser).ThenInclude(b => b.User).ToListAsync();
        }

        public async Task<Beer> GetBeer(int beerId)
        {
            return await _context.Beers.Where(b => b.BeerId == beerId).Include(b => b.Bitterness).Include(b => b.BeerUser).ThenInclude(b => b.User).SingleOrDefaultAsync();
        }
    }
}
