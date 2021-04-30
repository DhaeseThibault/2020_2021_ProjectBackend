using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using ProjectBackend.DTO;
using ProjectBackend.Models;
using ProjectBackend.Repositories;

namespace ProjectBackend.Services
{
    public interface IBeerService
    {
        Task<List<BrewerDTO>> GetBrewers();
        Task<List<Beer>> GetBeers();
        Task<Beer> GetBeer(int beerId);
        Task<List<UserDTO>> GetUsers();
        Task<BeerDTO> AddBeer(BeerDTO beer);        
    }

    public class BeerService : IBeerService
    {
        private IBrewerRepository _brewerRepository;
        private IBeerRepository _beerRepository;
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public BeerService(IMapper mapper, IBrewerRepository brewerRepository, IBeerRepository beerRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _brewerRepository = brewerRepository;
            _beerRepository = beerRepository;
            _userRepository = userRepository;
        }


        public async Task<List<BrewerDTO>> GetBrewers()
        {
            return _mapper.Map<List<BrewerDTO>>(await _brewerRepository.GetBrewers());
        }

        public async Task<List<Beer>> GetBeers()
        {
            return await _beerRepository.GetBeers();
        }

        public async Task<Beer> GetBeer(int beerId)
        {
            try
            {
                return await _beerRepository.GetBeer(beerId);
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        public async Task<BeerDTO> AddBeer(BeerDTO beer)
        {
            try
            {
                Beer newBeer = _mapper.Map<Beer>(beer);

                newBeer.BeerUser = new List<BeerUser>();
                foreach (var beerid in beer.Users)
                {
                    newBeer.BeerUser.Add(new BeerUser() { BeerId = beerid });
                }
                await _beerRepository.AddBeer(newBeer);
                return beer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<UserDTO>> GetUsers()
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.GetUsers());
        }
    }
}
