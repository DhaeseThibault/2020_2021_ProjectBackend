using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
// using ProjectBackend.DataContext;
using ProjectBackend.DTO;
// using ProjectBackend.Models;
using ProjectBackend.Services;

namespace ProjectBackend.Controllers
{
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


        
    }
}
