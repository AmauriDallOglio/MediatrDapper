using MediatR;
using MediatrDapper.Aplicacao.Usuarios;
using MediatrDapper.Dominio.Entidade;
using MediatrDapper.Infra.Contexto;
using Microsoft.AspNetCore.Mvc;

namespace MediatrDapperApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;


        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> InserirUsuarioMemoria([FromBody] InserirUsuarioMemoriaCommandResponse command)
        {
            var resultado = await _mediator.Send(command);
            return CreatedAtAction(nameof(InserirUsuarioMemoria), new { id = resultado.Id }, resultado);
        }

        [HttpGet]
        public IActionResult ListarUsuariosMemoria([FromServices] MemoriaContexto contexto)
        {
            var usuarios = contexto.ObterTodos();
            return Ok(usuarios);
        }




        [HttpPost("Inserir"), ActionName("Inserir")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Inserir([FromBody] InserirUsuarioCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response == null)
            {
                BadRequest(response);
            }
            return Ok(response);
        }




        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObterTodos()
        {
            var query = new ObterTodosUsuariosQueryRequest();
            var usuarios = await _mediator.Send(query);

            return Ok(usuarios);
        }



    }
}
