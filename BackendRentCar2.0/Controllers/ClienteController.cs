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
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClientesRepository _clientesRepository;
        public ClienteController(IMapper mapper, IClientesRepository clientesRepository)
        {
            _mapper = mapper;
            _clientesRepository = clientesRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listClientes = await _clientesRepository.GetClientes();
                var listClientesDTO = _mapper.Map<IEnumerable<ClientesDTO>>(listClientes);
                return Ok(listClientesDTO);
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
                var FindCliente = await _clientesRepository.GetClienteID(id);
                if (FindCliente == null)
                {
                    return NotFound();
                }
                var ClienteDTO = _mapper.Map<ClientesDTO>(FindCliente);

                return Ok(ClienteDTO);
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
                var FindCliente = await _clientesRepository.GetClienteID(id);
                if (FindCliente == null)
                {
                    return NotFound();
                }

                await _clientesRepository.DeleteCliente(FindCliente);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(ClientesDTO clientesDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                    var clientes = _mapper.Map<Cliente>(clientesDTO);
                    var clienteadd = await _clientesRepository.AddCliente(clientes);
                    var clienteitems = _mapper.Map<ClientesDTO>(clientes);
                    return CreatedAtAction("Get", new { id = clienteitems.Idcliente }, clienteitems);
 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ClientesDTO>> Put(int id, ClientesDTO clientesDTO)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var clientes = _mapper.Map<Cliente>(clientesDTO);
                clientes.IdCliente = id;

                await _clientesRepository.UpdateCliente(clientes);

                return _mapper.Map<ClientesDTO>(clientes);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
       
    }
}
