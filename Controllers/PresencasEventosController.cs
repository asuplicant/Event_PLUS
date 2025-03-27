using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using Events_PLUS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Events_PLUS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class PresencasEventosController : ControllerBase
    {
        private readonly IPresencaRepository _presencasEventosRepository;

        public PresencasEventosController(IPresencaRepository presencasEventosRepository)
        {
            _presencasEventosRepository = presencasEventosRepository;
        }
        [HttpPut]


        public IActionResult Put(Guid id, Presenca presenca)
        {
            try
            {
                _presencasEventosRepository.Atualizar(id, presenca);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _presencasEventosRepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Presenca> ListaPresencas = _presencasEventosRepository.Listar();
                return Ok(ListaPresencas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("ListarMinhas/{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<Presenca> ListaMinhas = _presencasEventosRepository.ListarMinhasPresencas(Id);
                return Ok(ListaMinhas);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                Presenca presencaBuscada = _presencasEventosRepository.BuscarPorId(Id);

                return Ok(presencaBuscada);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

