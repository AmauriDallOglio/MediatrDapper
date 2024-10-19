using MediatR;
using MediatrDapper.Dominio.Entidade;

namespace MediatrDapper.Command.Aplicacao.Usuarios
{
    public class InserirUsuarioMemoriaCommandResponse : IRequest<Usuario>
    {
        public string Nome { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
