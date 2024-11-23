using Application.App_Geral.UseCases.Usuarios.Command.CriarUsuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Admin
{
    [Tags("Geral")]
    [Route("api/geral/usuario")]
    [ApiExplorerSettings(GroupName = "geral")]
    public class UsuarioController : ControllerBase
    {
        private readonly ISender _sender;
        public UsuarioController(ISender sender)
        {
            _sender = sender;    
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuariosCommand request)
        {
            return Ok(await _sender.Send(request));
        }
    }
}
