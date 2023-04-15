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
    public class TiposdeVehiculosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITiposdeVehiculosRepository _tiposdeVehiculosRepository;
        public TiposdeVehiculosController(IMapper mapper, ITiposdeVehiculosRepository tiposdeVehiculosRepository)
        {
            _mapper = mapper;
            _tiposdeVehiculosRepository = tiposdeVehiculosRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listTiposVehiculos = await _tiposdeVehiculosRepository.GetVehiculos();
                var listTiposVehiculosDTO = _mapper.Map<IEnumerable<TiposdeVehiculosDTO>>(listTiposVehiculos);
                return Ok(listTiposVehiculosDTO);
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
                var FindTipoVehiculo = await _tiposdeVehiculosRepository.GetVehiculoID(id);
                if (FindTipoVehiculo == null)
                {
                    return NotFound();
                }
                var VehiculoDTO = _mapper.Map<TiposdeVehiculosDTO>(FindTipoVehiculo);

                return Ok(VehiculoDTO);
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
                var FindTipoVehiculo = await _tiposdeVehiculosRepository.GetVehiculoID(id);
                if (FindTipoVehiculo == null)
                {
                    return NotFound();
                }

                await _tiposdeVehiculosRepository.DeleteVehiculo(FindTipoVehiculo);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(TiposdeVehiculosDTO tiposdeVehiculosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var Vehiculo = _mapper.Map<TiposdeVehiculo>(tiposdeVehiculosDTO);
                var Vehiculoadd = await _tiposdeVehiculosRepository.AddVehiculo(Vehiculo);
                var Vehiculoitems = _mapper.Map<TiposdeVehiculosDTO>(Vehiculo);
                return CreatedAtAction("Get", new { id = Vehiculoitems.IdTiposVehiculo }, Vehiculoitems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TiposdeVehiculosDTO>> Put(int id, TiposdeVehiculosDTO tiposdeVehiculosDTO)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var vehiculoTipo = _mapper.Map<TiposdeVehiculo>(tiposdeVehiculosDTO);
                vehiculoTipo.IdTiposVehiculo = id;

                await _tiposdeVehiculosRepository.UpdateVehiculo(vehiculoTipo);

                return _mapper.Map<TiposdeVehiculosDTO>(tiposdeVehiculosDTO);
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
