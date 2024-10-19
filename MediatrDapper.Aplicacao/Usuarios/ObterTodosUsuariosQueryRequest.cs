using MediatR;
using MediatrDapper.Dominio.Entidade;

namespace MediatrDapper.Aplicacao.Usuarios
{
    public class ObterTodosUsuariosQueryRequest : IRequest<IEnumerable<Usuario>>
    {
    }
}
