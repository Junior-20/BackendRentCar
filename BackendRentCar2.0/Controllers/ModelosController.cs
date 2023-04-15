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
    public class ModelosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IModelosRepository _modelosRepository;
        public ModelosController(IMapper mapper, IModelosRepository modelosRepository)
        {
            _mapper = mapper;
            _modelosRepository = modelosRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listModelos = await _modelosRepository.GetModelo();
                var listModeloDTO = _mapper.Map<IEnumerable<ModelosDTO>>(listModelos);
                return Ok(listModeloDTO);
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
                var FindModelo = await _modelosRepository.GetModeloID(id);
                if (FindModelo == null)
                {
                    return NotFound();
                }
                var ModeloDTO = _mapper.Map<ModelosDTO>(FindModelo);

                return Ok(ModeloDTO);
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
                var FindModelo = await _modelosRepository.GetModeloID(id);
                if (FindModelo == null)
                {
                    return NotFound();
                }

                await _modelosRepository.DeleteModelo(FindModelo);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(ModelosDTO modelo)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var modelos = _mapper.Map<Modelo>(modelo);
                var modeloadd = _modelosRepository.AddModelo(modelos);
                var modelositems = _mapper.Map<ModelosDTO>(modelos);
                return CreatedAtAction("Get", new { id = modelositems.IdModelo }, modelositems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModelosDTO>> Put(int id, ModelosDTO modelosDTO)
        {

            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var modelo = _mapper.Map<Modelo>(modelosDTO);
                modelo.IdModelo = id;

                await _modelosRepository.UpdateModelo(modelo);

                return _mapper.Map<ModelosDTO>(modelo);
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
