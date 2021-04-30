using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBackend.DataContext;
using ProjectBackend.Models;

namespace ProjectBackend.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
    
    public class UserRepository : IUserRepository
    {
        private IBeerContext _context;
        public UserRepository(IBeerContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
