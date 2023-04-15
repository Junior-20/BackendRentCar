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
    public class InspeccionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInspeccionRepository _inspeccionRepository;
        public InspeccionController(IMapper mapper, IInspeccionRepository inspeccionRepository)
        {
            _mapper = mapper;
            _inspeccionRepository = inspeccionRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listInspecciones = await _inspeccionRepository.GetInspecciones();
                var listInspeccionesDTO = _mapper.Map<IEnumerable<InspeccionDTO>>(listInspecciones);
                return Ok(listInspeccionesDTO);
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
                var FindInspeccion = await _inspeccionRepository.GetInspeccionID(id);
                if (FindInspeccion == null)
                {
                    return NotFound();
                }
                var InspeccionDTO = _mapper.Map<InspeccionDTO>(FindInspeccion);

                return Ok(InspeccionDTO);
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
                var FindInspeccion = await _inspeccionRepository.GetInspeccionID(id);
                if (FindInspeccion == null)
                {
                    return NotFound();
                }

                await _inspeccionRepository.DeleteInspeccion(FindInspeccion);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(InspeccionDTO inspeccionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var Inspecciones = _mapper.Map<Inspeccion>(inspeccionDTO);
                var Inspeccionadd = await _inspeccionRepository.AddInspeccion(Inspecciones);
                var Inspeccionitems = _mapper.Map<InspeccionDTO>(Inspecciones);
                return CreatedAtAction("Get", new { id = Inspeccionitems.IdTransaccion }, Inspeccionitems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<InspeccionDTO>> Put(int id, InspeccionDTO inspeccionDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Inspecciones = _mapper.Map<Inspeccion>(inspeccionDTO);
                Inspecciones.IdTransaccion = id;

                await _inspeccionRepository.UpdateInspeccion(Inspecciones);

                return _mapper.Map<InspeccionDTO>(Inspecciones);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
