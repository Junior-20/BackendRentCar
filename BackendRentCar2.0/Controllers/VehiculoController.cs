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
    public class VehiculoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehiculosRepository _vehiculosRepository;
        public VehiculoController(IMapper mapper, IVehiculosRepository vehiculosRepository)
        {
            _mapper = mapper;
            _vehiculosRepository = vehiculosRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listVehiculos = await _vehiculosRepository.GetVehiculos();
                var listVehiculosDTO = _mapper.Map<IEnumerable<VehiculosDTO>>(listVehiculos);
                return Ok(listVehiculosDTO);
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
                var FindVehiculo = await _vehiculosRepository.GetVehiculoID(id);
                if (FindVehiculo == null)
                {
                    return NotFound();
                }
                var VehiculoDTO = _mapper.Map<VehiculosDTO>(FindVehiculo);

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
                var FindVehiculo = await _vehiculosRepository.GetVehiculoID(id);
                if (FindVehiculo == null)
                {
                    return NotFound();
                }

                await _vehiculosRepository.DeleteVehiculo(FindVehiculo);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(VehiculosDTO vehiculosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var vehiculo = _mapper.Map<Vehiculo>(vehiculosDTO);
                var Vehiculoadd = await _vehiculosRepository.AddVehiculo(vehiculo);
                var Vehiculoitems = _mapper.Map<VehiculosDTO>(vehiculo);
                return CreatedAtAction("Get", new { id = Vehiculoitems.IdVehiculos }, Vehiculoitems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehiculosDTO>> Put(int id, VehiculosDTO vehiculosDTO)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Vehiculo = _mapper.Map<Vehiculo>(vehiculosDTO);
                Vehiculo.IdVehiculos = id;

                await _vehiculosRepository.UpdateVehiculo(Vehiculo);

                return _mapper.Map<VehiculosDTO>(Vehiculo);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
