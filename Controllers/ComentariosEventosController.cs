using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Events_PLUS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ComentariosEventosController : ControllerBase
    {
        private readonly IComentariosEventosRepository _comentariosEventosRepository;

        public ComentariosEventosController(IComentariosEventosRepository comentariosEventosRepository)
        {
            _comentariosEventosRepository = comentariosEventosRepository;
        }

        [HttpPost]
        public IActionResult Post(Comentarios comentarioEvento)
        {
            try
            {
                _comentariosEventosRepository.Cadastrar(comentarioEvento);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
