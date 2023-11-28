using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGamesAPI.CustomActionFilters;
using MyGamesAPI.Data;
using MyGamesAPI.Mappings;
using MyGamesAPI.Models.Domain;
using MyGamesAPI.Models.DTO;
using MyGamesAPI.Repositories;

namespace MyGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private readonly MyGamesApiDbContext _dbContext;
        private readonly IStudioRepository _studioRepository;
        private readonly IMapper _mapper;

        public StudioController(MyGamesApiDbContext dbContext, IStudioRepository studioRepository, IMapper mapper)
        {
            _dbContext= dbContext;
            _studioRepository= studioRepository;
            _mapper=mapper;
        }

        //Get all Studios
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get from db
            var studioDomain = await _studioRepository.GetAllAsync();

            //map domain models to Dto's
            var studioDto = _mapper.Map<List<StudioDto>>(studioDomain);

            return Ok(studioDto);
        }

        //Get Studio by Id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var studioDomain = await _studioRepository.GetByIdAsync(id);

            if(studioDomain == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<StudioDto>(studioDomain));
        }

        //Create new Studio
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddStudioRequestDto addStudioRequestDto)
        {
                //map Dto to Domain model
                var studioDomainModel = _mapper.Map<Studio>(addStudioRequestDto);

                studioDomainModel = await _studioRepository.CreateAsync(studioDomainModel);

                //map domain to Dto
                var studioDto = _mapper.Map<StudioDto>(studioDomainModel);

                return Ok(studioDto);

        }

        //PUT Update Studio
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id , [FromBody] UpdateStudioRequestDto updateStudioRequestDto)
        {

                //map Dto to domain
                var studioDomainModel = _mapper.Map<Studio>(updateStudioRequestDto);

                studioDomainModel = await _studioRepository.UpdateAsync(id, studioDomainModel);

                if (studioDomainModel == null)
                {
                    return NotFound();
                }

                //DomainModel to DTO
                return Ok(_mapper.Map<StudioDto>(studioDomainModel));
        }

        //DELETE Studio
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var studioDomainModel = await _studioRepository.DeleteAsync(id);

            if(studioDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudioDto>(studioDomainModel));

        }
    }
}
