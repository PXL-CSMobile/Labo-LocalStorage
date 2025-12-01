using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PieShop.API.Entities;
using PieShop.API.Models;
using PieShop.API.Repositories;

namespace PieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiesController : ControllerBase
    {
        private readonly IPieRepository _repository;
        private readonly IMapper _mapper;

        public PiesController(IPieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieDto>>> GetPies()
        {
            var pies = await _repository.GetPiesAsync();
            return Ok(_mapper.Map<IEnumerable<PieDto>>(pies));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PieDto>>> GetPie(Guid id)
        {
            var pie = await _repository.GetPieAsync(id);

            if (pie is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PieDto>(pie));
        }

        [HttpPost]
        public async Task<ActionResult<PieDto>> AddPie(PieDto pieDto)
        {
            //pieDto.Id is leeg en wordt toegewezen door de database
            Pie pie = _mapper.Map<Pie>(pieDto);
            await _repository.AddPieAsync(pie); //pie.Id bevat nu het nieuwe id

            pieDto = _mapper.Map<PieDto>(pie); //projecteer de pie entity naar de pieDto
            //return statuscode 201 met de nieuwe pieDto als body
            return CreatedAtAction(nameof(GetPie), new { id = pie.Id }, pieDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePie(PieDto pieDto)
        {
            var pie = await _repository.GetPieAsync(pieDto.Id);

            if (pie is null)
            {
                return BadRequest();
            }

            await _repository.UpdatePieAsync((_mapper.Map<Pie>(pieDto)));

            return NoContent(); //Statuscode 204
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePie(Guid id)
        {
            var pie = await _repository.GetPieAsync(id);

            if (pie is null)
            {
                return NotFound();
            }

            await _repository.DeletePieAsync(pie);

            return NoContent();
        }
    }
}
