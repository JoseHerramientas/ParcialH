
using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace ParcialCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tiposSegurosController : ControllerBase
    {
        public readonly iTiposSegurosRepository _tiposSegurosRepository;
        public tiposSegurosController(iTiposSegurosRepository tiposSegurosRepository)
        {
            _tiposSegurosRepository = tiposSegurosRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getTipoSeguro()
        {
            return Ok(await _tiposSegurosRepository.getTipoSeguro());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getTipoSeguroById(int id)
        {
            return Ok(await _tiposSegurosRepository.getTipoSeguroById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertTipoSeguro([FromBody] tiposSeguros tipoSeguro)
        {
            if (tipoSeguro == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _tiposSegurosRepository.insertTipoSeguro(tipoSeguro);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTipoSeguro([FromBody] tiposSeguros tipoSeguro)
        {
            if (tipoSeguro == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _tiposSegurosRepository.insertTipoSeguro(tipoSeguro);
            return Ok(created);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTipoSeguroById(int id)
        {
            return Ok(await _tiposSegurosRepository.deleteTipoSeguro(id));
        }
    }

}
