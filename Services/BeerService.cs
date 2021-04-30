using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectBackend.DTO;
using ProjectBackend.Repositories;
using ProjectBackend.Models;

namespace ProjectBackend.Services
{
    public interface IBeerService
    {
        Task<List<BrewerDTO>> GetBrewers();
        Task<List<Beer>> GetBeers();
        Task<Beer> GetBeer(int beerId);
    }

    public class BeerService : IBeerService
    {
        private IBrewerRepository _brewerRepository;
        private IBeerRepository _beerRepository;
        private IMapper _mapper;

        public BeerService(IMapper mapper, IBrewerRepository brewerRepository, IBeerRepository beerRepository)
        {
            _mapper = mapper;
            _brewerRepository = brewerRepository;
            _beerRepository = beerRepository;
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
    }
}
