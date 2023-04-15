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
    public class RentaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRentaRepository _rentaRepository;
        public RentaController(IMapper mapper, IRentaRepository rentaRepository)
        {
            _mapper = mapper;
            _rentaRepository = rentaRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listRentas = await _rentaRepository.GetRentas();
                var listRentasDTO = _mapper.Map<IEnumerable<RentaDTO>>(listRentas);
                return Ok(listRentasDTO);
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
                var FindRenta = await _rentaRepository.GetRentaID(id);
                if (FindRenta == null)
                {
                    return NotFound();
                }
                var rentaDTO = _mapper.Map<RentaDTO>(FindRenta);

                return Ok(rentaDTO);
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
                var FindRenta = await _rentaRepository.GetRentaID(id);
                if (FindRenta == null)
                {
                    return NotFound();
                }

                await _rentaRepository.DeleteRenta(FindRenta);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(RentaDTO rentaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var Rentas = _mapper.Map<Rentum>(rentaDTO);
                var Rentaadd = await _rentaRepository.AddRenta(Rentas);
                var Rentaitems = _mapper.Map<RentaDTO>(Rentas);
                return CreatedAtAction("Get", new { id = Rentaitems.IdRenta }, Rentaitems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<RentaDTO>> Put(int id, RentaDTO rentaDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var renta = _mapper.Map<Rentum>(rentaDTO);
                renta.IdRenta = id;

                await _rentaRepository.UpdateRenta(renta);

                return _mapper.Map<RentaDTO>(renta);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
