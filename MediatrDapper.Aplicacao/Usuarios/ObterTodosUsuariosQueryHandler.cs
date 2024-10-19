using MediatR;
using MediatrDapper.Dominio.Entidade;
using MediatrDapper.Dominio.Interface;

namespace MediatrDapper.Aplicacao.Usuarios
{
    public class ObterTodosUsuariosQueryHandler : IRequestHandler<ObterTodosUsuariosQueryRequest, IEnumerable<Usuario>>
    {
        private readonly IUsuarioRepositorio _iusuarioRepositorio;

        public ObterTodosUsuariosQueryHandler(IUsuarioRepositorio iusuarioRepositorio)
        {
            _iusuarioRepositorio = iusuarioRepositorio;
        }


        public async Task<IEnumerable<Usuario>> Handle(ObterTodosUsuariosQueryRequest request, CancellationToken cancellationToken)
        {


            var usuarios = _iusuarioRepositorio.ObterTodosDapper();


            return usuarios;
        }
    }
}
