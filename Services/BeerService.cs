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
    }

    public class BeerService : IBeerService
    {
        private IBrewerRepository _brewerRepository;
        private IMapper _mapper;

        public BeerService(IMapper mapper, IBrewerRepository brewerRepository)
        {
            _mapper = mapper;
            _brewerRepository = brewerRepository;
        }



        public async Task<List<BrewerDTO>> GetBrewers()
        {
            return _mapper.Map<List<BrewerDTO>>(await _brewerRepository.GetBrewers());
        }
    }
}
