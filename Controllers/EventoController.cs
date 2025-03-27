using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Events_PLUS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;
        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        //---------------------------------------------------------------------------------
        // Listar

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //---------------------------------------------------------------------------------
        // Cadastrar

        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //---------------------------------------------------------------------------------
        // Deletar

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Cadastrar
        [HttpPut]
        public IActionResult Put(Guid id, Evento novoEvento)
        {
            try
            {
                _eventoRepository.Atualizar(id, novoEvento);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpGet("ListarProximosEventos/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Evento> listarEvento = _eventoRepository.ListarProximosEventos(id);
                return Ok(listarEvento);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }

        [HttpGet("ListarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                List<Evento> listarEvento = _eventoRepository.ListarPorId(id);
                return Ok(listarEvento);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}