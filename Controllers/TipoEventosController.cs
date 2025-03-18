using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Events_PLUS.Controllers
{
    public class TipoEventosController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class TiposEventosController : ControllerBase
        {
            private readonly ITiposEventosRepository _tiposEventosRepository;
            public TiposEventosController(ITiposEventosRepository tiposEventosRepository)
            {
                _tiposEventosRepository = tiposEventosRepository;
            }
            // Cadastrar TiposEventos
            [HttpPost]
            public IActionResult Post(TiposEventos tiposEventos)
            {
                try
                {
                    _tiposEventosRepository.Cadastrar(tiposEventos);

                    return Created();
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }
            // Deletar
            [HttpDelete("{id}")]
            public IActionResult DeleteById(Guid id)
            {
                try
                {
                    _tiposEventosRepository.Deletar(id);
                    return NoContent();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            // Listar TiposEventos
            [HttpGet]
            public IActionResult Get()
            {
                try
                {
                    List<TiposEventos> listaDeEventos = _tiposEventosRepository.Listar();
                    return Ok(listaDeEventos);
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }

            // BuscarPorId 
            [HttpGet("BuscarPorId/{id}")]
            public IActionResult GetById(Guid id, TiposEventos tiposEventos)
            {
                try
                {
                    TiposEventos tiposEventosBuscado = _tiposEventosRepository.BuscarPorId(id);
                    return Ok(tiposEventosBuscado);
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }
            [HttpPut("{id}")]
            public IActionResult Put(Guid id, TiposEventos tiposEventos)
            {
                try
                {
                    _tiposEventosRepository.Atualizar(id, tiposEventos);

                    return NoContent();
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }

            }

        }
    }
}
