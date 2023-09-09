
using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace ParcialCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class empleadosController : ControllerBase
    {
        public readonly iEmpleadosRepository _empleadosRepository;
        public empleadosController(iEmpleadosRepository empleadosRepository)
        {
            _empleadosRepository = empleadosRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getCliente()
        {
            return Ok(await _empleadosRepository.getEmpleados());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getEmpleadosById(int id)
        {
            return Ok(await _empleadosRepository.getEmpleadosById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertEmpleados([FromBody] empleados empleado)
        {
            if (empleado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _empleadosRepository.insertEmpleados(empleado);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmpleados([FromBody] empleados empleado)
        {
            if (empleado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _empleadosRepository.insertEmpleados(empleado);
            return Ok(created);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClienteById(int id)
        {
            return Ok(await _empleadosRepository.deleteEmpleados(id));
        }
    }

}
