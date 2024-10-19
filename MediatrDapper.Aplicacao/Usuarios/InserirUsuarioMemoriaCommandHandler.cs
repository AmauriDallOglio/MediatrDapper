using MediatR;
using MediatrDapper.Dominio.Entidade;
using MediatrDapper.Infra.Contexto;

namespace MediatrDapper.Aplicacao.Usuarios
{
    public class InserirUsuarioMemoriaCommandHandler : IRequestHandler<InserirUsuarioMemoriaCommandResponse, Usuario>
    {
        private readonly MemoriaContexto _memoriaContexto;

        public InserirUsuarioMemoriaCommandHandler(MemoriaContexto memoriaContexto)
        {
            _memoriaContexto = memoriaContexto;
        }

        public Task<Usuario> Handle(InserirUsuarioMemoriaCommandResponse request, CancellationToken cancellationToken)
        {
            var novoUsuario = new Usuario
            {
                Id = _memoriaContexto.ObterTodos().Count() + 1,
                Nome = request.Nome,
                Codigo = request.Codigo,
                Email = request.Email
            };

            _memoriaContexto.Adicionar(novoUsuario);
            return Task.FromResult(novoUsuario);
        }
    }
}