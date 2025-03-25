using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using Events_PLUS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Events_PLUS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        //---------------------------------------------------------------------------------
        // Cadastrar
        [HttpPost]
        public IActionResult Post(Usuarios usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //---------------------------------------------------------------------------------
        // Buscar por Id

        [HttpGet("{id}")]

        public IActionResult GetByID(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }

                return null!;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //---------------------------------------------------------------------------------
        // Listar Por Tipo

        [HttpGet("tipoUsuario/{idTipoUsuario}")]
        public IActionResult ListarPorTipo(Guid idTipoUsuario)
        {
            List<Usuarios> usuario = _usuarioRepository.ListarPorTipo(idTipoUsuario);
            Console.WriteLine(usuario);

            if (usuario == null)
            {
                return NotFound("Nenhum usuario encontrado para esse tipo de usuario.");
            }

            return Ok(usuario);
        }
    }
}
    