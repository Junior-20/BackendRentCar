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
    public class MarcasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMarcasRepository _marcasRepository;
        public MarcasController(IMapper mapper, IMarcasRepository marcasRepository)
        {
            _mapper = mapper;
            _marcasRepository = marcasRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listMarcas = await _marcasRepository.GetMarcas();
                var listMarcasDTO = _mapper.Map<IEnumerable<MarcasDTO>>(listMarcas);
                return Ok(listMarcasDTO);
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
                var FindMarca = await _marcasRepository.GetMarcaID(id);
                if (FindMarca == null)
                {
                    return NotFound();
                }
                var MarcaDTO = _mapper.Map<MarcasDTO>(FindMarca);

                return Ok(MarcaDTO);
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
                var FindMarca = await _marcasRepository.GetMarcaID(id);
                if (FindMarca == null)
                {
                    return NotFound();
                }

                await _marcasRepository.DeleteMarca(FindMarca);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(MarcasDTO marcasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var marcas = _mapper.Map<Marcass>(marcasDTO);
                var marcaadd = await _marcasRepository.AddMarca(marcas);
                var marcasitems = _mapper.Map<MarcasDTO>(marcas);
                return CreatedAtAction("Get", new { id = marcasitems.IdMarca }, marcasitems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<MarcasDTO>> Put(int id, MarcasDTO marcasDTO)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var marcas = _mapper.Map<Marcass>(marcasDTO);
                marcas.IdMarca = id;

                await _marcasRepository.UpdateMarca(marcas);

                return _mapper.Map<MarcasDTO>(marcas);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
