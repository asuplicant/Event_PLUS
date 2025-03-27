using Events_PLUS.Domains;
using Events_PLUS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Events_PLUS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tiposUsuariosRepository;

        public UsuarioController(ITipoUsuarioRepository tiposUsuariosRepository)
        {
            _tiposUsuariosRepository = tiposUsuariosRepository;
        }

        //---------------------------------------------------------------------------------
        // Listar
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposUsuariosRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        //---------------------------------------------------------------------------------
        // Cadastrar
        [HttpPost]
        public IActionResult Post(TipoUsuarios novoTipoUsuario)
        {
            try
            {
                _tiposUsuariosRepository.Cadastrar(novoTipoUsuario);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //---------------------------------------------------------------------------------
        // Buscar Por Id
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoUsuarios tipoBuscado = _tiposUsuariosRepository.BuscarPorId(id);
                return Ok(tipoBuscado);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //---------------------------------------------------------------------------------
        // Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposUsuariosRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }

        }

        //---------------------------------------------------------------------------------
        // Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoUsuarios tipoUsuario)
        {
            try
            {
                _tiposUsuariosRepository.Atualizar(id, tipoUsuario);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }
    }
}