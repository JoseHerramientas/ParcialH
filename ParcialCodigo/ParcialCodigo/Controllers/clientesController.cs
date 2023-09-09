
using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace ParcialCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly iClientesRepository _clientesRepository;
        public ClienteController(iClientesRepository clienteRepository)
        {
            _clientesRepository = clienteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getCliente()
        {
            return Ok(await _clientesRepository.getClientes());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getClienteById(int id)
        {
            return Ok(await _clientesRepository.getClienteById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] clientes cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _clientesRepository.insertCliente(cliente);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] clientes cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _clientesRepository.insertCliente(cliente);
            return Ok(created);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClienteById(int id)
        {
            return Ok(await _clientesRepository.deleteCliente(id));
        }
    }

}
