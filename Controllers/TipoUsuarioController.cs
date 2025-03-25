using Events_PLUS.Domains;
using Events_PLUS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Events_PLUS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : Controller
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        //---------------------------------------------------------------------------------
        // Cadastrar
        [HttpPost]
        public IActionResult Post(TipoUsuarios tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);
                return StatusCode(201, tipoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        //---------------------------------------------------------------------------------
        // Deletar
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Listar
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoUsuarios> listaDosUsuarios = _tipoUsuarioRepository.Listar();
                return Ok(listaDosUsuarios);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        //---------------------------------------------------------------------------------
        // Buscar por Id
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoUsuarios tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);
                return Ok(tipoUsuarioBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        // Atualizar 
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoUsuarios tiposUsuarios)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tiposUsuarios);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}