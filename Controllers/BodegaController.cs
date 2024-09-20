using induccionef.Models;
using induccionef.Repositories;
using Microsoft.AspNetCore.Mvc;
using induccionef.Pagination;

namespace induccionef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegaController: ControllerBase
    {

        private readonly BodegaRepository _bodegaRepository;

        public BodegaController(BodegaRepository bodegaRepository){

            _bodegaRepository = bodegaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){

            var bodegas = await _bodegaRepository.GetAllAsync();

            return Ok(bodegas);
        }

        [HttpPost]
        public async Task<ActionResult<Bodega>> PostBodega(Bodega bodega){

            if (bodega == null)
            {
                return BadRequest("Error");
            }

            await _bodegaRepository.AddAsync(bodega);

            return Ok();
        }

    }
}

