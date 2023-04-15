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
    public class EmpleadoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmpleadosRepository _empleadosRepository;
        public  EmpleadoController(IMapper mapper, IEmpleadosRepository empleadosRepository)
        {
            _mapper = mapper;
            _empleadosRepository = empleadosRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listEmpleados = await _empleadosRepository.GetEmpleados();
                var listEmpleadosDTO = _mapper.Map<IEnumerable<EmpleadosDTO>>(listEmpleados);
                return Ok(listEmpleadosDTO);
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
                var FindEmpleado = await _empleadosRepository.GetEmpleadoID(id);
                if (FindEmpleado == null)
                {
                    return NotFound();
                }
                var EmpleadoDTO = _mapper.Map<EmpleadosDTO>(FindEmpleado);

                return Ok(EmpleadoDTO);
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
                var FindEmpleado = await _empleadosRepository.GetEmpleadoID(id);
                if (FindEmpleado == null)
                {
                    return NotFound();
                }

                await _empleadosRepository.DeleteEmpleado(FindEmpleado);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(EmpleadosDTO empleadosDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var Empleados = _mapper.Map<Empleado>(empleadosDTO);
                var Empleadosadd = await _empleadosRepository.AddEmpleado(Empleados);
                var Empleadositems = _mapper.Map<EmpleadosDTO>(Empleados);
                return CreatedAtAction("Get", new { id = Empleadositems.IdEmpleado }, Empleadositems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EmpleadosDTO>> Put(int id, EmpleadosDTO empleadosDTO)
        {

            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var empleados = _mapper.Map<Empleado>(empleadosDTO);
                empleados.IdEmpleado = id;

                await _empleadosRepository.UpdateEmpleado(empleados);

                return _mapper.Map<EmpleadosDTO>(empleados);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public static bool validaCedula(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }
    }
}
