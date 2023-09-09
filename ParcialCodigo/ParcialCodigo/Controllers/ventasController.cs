
using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace ParcialCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ventasController : ControllerBase
    {
        public readonly iVentasRepository _ventasRepository;
        public ventasController(iVentasRepository ventasRepository)
        {
            _ventasRepository = ventasRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getVenta()
        {
            return Ok(await _ventasRepository.getVenta());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getVentaById(int id)
        {
            return Ok(await _ventasRepository.getVentaById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertVenta([FromBody] ventas venta)
        {
            if (venta == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _ventasRepository.insertVenta(venta);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVenta([FromBody] ventas venta)
        {
            if (venta == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _ventasRepository.insertVenta(venta);
            return Ok(created);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVentaById(int id)
        {
            return Ok(await _ventasRepository.deleteVenta(id));
        }
    }

}
