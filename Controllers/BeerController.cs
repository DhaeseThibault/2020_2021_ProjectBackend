using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

// using ProjectBackend.DataContext;
using ProjectBackend.DTO;
using ProjectBackend.Models;
using ProjectBackend.Services;

namespace ProjectBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;
        private readonly ILogger<BeerController> _logger;
        public BeerController(ILogger<BeerController> logger, IBeerService beerService)
        {
            _logger = logger;
            _beerService = beerService;
        }


        [HttpGet]
        [Route("brewers")]  
        public async Task<ActionResult<List<BrewerDTO>>> GetBrewers()
        {
            try
            {
                return new OkObjectResult(await _beerService.GetBrewers());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    

        [HttpGet]
        [Route("beers")]
        public async Task<ActionResult<List<Beer>>> GetBeers()
        {
            try
            {
                return new OkObjectResult(await _beerService.GetBeers());
            }   
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("beer/{BeerId}")]
        public async Task<ActionResult<List<Beer>>> GetBeer(int beerId)
        {
            try
            {
                return new OkObjectResult(await _beerService.GetBeer(beerId));
            }   
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            try
            {
                return new OkObjectResult(await _beerService.GetUsers());
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("beers")]
        public async Task<ActionResult<BeerDTO>> AddBeer(BeerDTO beer)
        {
            try
            {
                return new OkObjectResult(await _beerService.AddBeer(beer));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
