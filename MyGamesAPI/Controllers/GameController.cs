using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGamesAPI.CustomActionFilters;
using MyGamesAPI.Data;
using MyGamesAPI.Models.Domain;
using MyGamesAPI.Models.DTO;
using MyGamesAPI.Repositories;

namespace MyGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly MyGamesApiDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        public GameController(MyGamesApiDbContext dbcontext, IMapper mapper, IGameRepository gameRepository)
        {
            _mapper= mapper;
            _dbcontext = dbcontext;
            _gameRepository = gameRepository;
        }

        //Get All Games
        // /api/games?filterOn=Type&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            var gameDomain = await _gameRepository.GetAllAsync();

            //map domain to dto
            return Ok(_mapper.Map<List<GameDto>>(gameDomain));
        }

        //Get By Id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var gameDomain = _gameRepository.GetByIdAsync(id);

            if (gameDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GameDto>(gameDomain));
        }

        //POST Create Game
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddGameRequestDto addGameRequestDto)
        {
         
                var gameDomain = _mapper.Map<Game>(addGameRequestDto);

                await _gameRepository.CreateAsync(gameDomain);

                //Map domain to Dto
                return Ok(_mapper.Map<GameDto>(gameDomain));  
    
        }

        //PUT Update Games
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id , UpdateGameRequestDto updateGameRequestDto)
        {
                //map Dto to domain
                var gameDomainModel = _mapper.Map<Game>(updateGameRequestDto);


                gameDomainModel = await _gameRepository.UpdateAsync(id, gameDomainModel);

                if (gameDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GameDto>(gameDomainModel));

        }

        //DELETE 
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleteGameDomainModel = await _gameRepository.DeleteAsync(id);

            if(deleteGameDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GameDto>(deleteGameDomainModel));
        }


    }
}
