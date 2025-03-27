using Events_PLUS.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Events_PLUS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tiposUsuariosRepository;

        public TipoUsuarios tipoUsuario (ITipoUsuarioRepository tiposUsuariosRepository)
        {
            _tiposUsuariosRepository = tiposUsuariosRepository;
        }
    }
}
