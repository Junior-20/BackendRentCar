using AutoMapper;
using BackendRentCar2._0.DTOs;
using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendRentCar2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipodeCombustibleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITiposdeCombustiblesRepository _tiposdeCombustiblesRepository;
        public TipodeCombustibleController(IMapper mapper, ITiposdeCombustiblesRepository tiposdeCombustiblesRepository)
        {
            _mapper = mapper;
            _tiposdeCombustiblesRepository = tiposdeCombustiblesRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listCombustibles = await _tiposdeCombustiblesRepository.GetCombustibles();
                var listCombustiblesDTO = _mapper.Map<IEnumerable<TiposdeCombustibleDTO>>(listCombustibles);
                return Ok(listCombustiblesDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var FindCombustible = await _tiposdeCombustiblesRepository.GetCombustibleID(id);
                if (FindCombustible == null)
                {
                    return NotFound();
                }
                var CombustibleDTO = _mapper.Map<TiposdeCombustibleDTO>(FindCombustible);

                return Ok(CombustibleDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var Combustible = await _tiposdeCombustiblesRepository.GetCombustibleID(id);
                if (Combustible == null)
                {
                    return NotFound();
                }

                await _tiposdeCombustiblesRepository.DeleteCombustible(Combustible);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(TiposdeCombustibleDTO tiposdeCombustibleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var combustible = _mapper.Map<TiposdeCombustible>(tiposdeCombustibleDTO);
                var combustibleadd = _tiposdeCombustiblesRepository.AddCombustible(combustible);
                var Combustiblesitems = _mapper.Map<TiposdeCombustibleDTO>(combustible);
                return CreatedAtAction("Get", new { id = Combustiblesitems.IdTiposCombustible }, Combustiblesitems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TiposdeCombustibleDTO>> Put(int id, TiposdeCombustibleDTO tiposdeCombustibleDTO)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var combustible = _mapper.Map<TiposdeCombustible>(tiposdeCombustibleDTO);
                combustible.IdTiposCombustible = id;

                await _tiposdeCombustiblesRepository.UpdateCombustible(combustible);

                return _mapper.Map<TiposdeCombustibleDTO>(combustible);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
